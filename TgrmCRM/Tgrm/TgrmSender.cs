using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;
using TLSchema;
using TLSchema.Contacts;
using TLSharp;

namespace TgrmCRM.Tgrm
{
    public class TgrmSender
    {
        private TgrmAuth client;
        private IContactService сontactService;
        private IThemeMessageService themeMessageService;
        private IAccountService accountService;
        private IKeyAnswerService keyAnswerService;
        private IContactsMessageService contactsMessageService;

        public TgrmSender(TgrmAuth tgrm, IContactService сontactService, IThemeMessageService themeMessageService, IAccountService accountService,
            IKeyAnswerService keyAnswerService, IContactsMessageService contactsMessageService)
        {
            client = tgrm;
            this.сontactService = сontactService;
            this.themeMessageService = themeMessageService;
            this.accountService = accountService;
            this.keyAnswerService = keyAnswerService;
            this.contactsMessageService = contactsMessageService;
        }

        public async Task<bool> MakeSents(IList<UserTL> users, IList<string> usernames, string message, List<string> positive, List<string> negative, string tel)
        {
            var acc = TgrmAuth.clients.First(p => p.Key.Phone == tel);
            if (!acc.Value.IsConnected)
            {
                await acc.Value.ConnectAsync();
            }
            var dt = DateTime.Now;

            var tlUsers = new List<TLUser>();
            foreach (var user in usernames)
            {
                var u = await GetUser(user, acc.Value);
                tlUsers.Add(u);
            }

            var contacts = tlUsers.Select(x => new Contact { DateAdd = dt, TgrmId = x.Id, Hash = x.AccessHash.Value });
            await сontactService.Add(contacts);

            var updates = new List<TLAbsUpdates>();
            foreach (var user in tlUsers)
            {
                var update = await SendMessage(message, user.Id, user.AccessHash.Value, acc.Value);
                updates.Add(update);
            }

            await themeMessageService.Add(new ThemeMessage { Account = accountService.Get(x => x.Tels == tel).First(), Body = message, DateAdd = dt });
            var messageDal = themeMessageService.Get(p => p.Body == message).First();

            var tasks = new[]
            {
                keyAnswerService.Add(positive.Select(x => new KeyAnswer { IsPositive = true, Keyword = x, Message = messageDal })),
                keyAnswerService.Add(negative.Select(x => new KeyAnswer { IsPositive = false, Keyword = x, Message = messageDal }))
            };

            var contactsDal = сontactService.Get(x => x.DateAdd == dt);

            var contMess = contactsDal.Select(x => new ContactsMessages { Contact = x, IsAccepted = false, Message = messageDal });
            await contactsMessageService.Add(contMess);

            return true;
        }

        private async Task<TLUser> GetUser(string username, TelegramClient client)
        {
            try
            {
                var f = await client.SearchUserAsync(username, 1);
                return f.Users.FirstOrDefault() as TLUser;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private async Task<TLAbsUpdates> SendMessage(string message, int userId, long accessHash, TelegramClient acc)
        {
            return await acc.SendMessageAsync(new TLInputPeerUser() { UserId = userId, AccessHash = accessHash }, message);
        }
    }
}
