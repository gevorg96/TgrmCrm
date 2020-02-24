using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TLSchema;
using TLSchema.Messages;
using TLSharp;

namespace TgrmCRM.Tgrm
{
    public class TgrmAuth
    {
        public bool IsAuthentificated
        {
            get => client.IsUserAuthorized();
        }

        private TelegramClient client = new TelegramClient(922350, "6a6dc6beb4825a7ae7bea7da57e17c63");
        private string hash;
        private TLUser user;
        

        public async Task Auth(string tel)
        {
            await client.ConnectAsync();
            hash = await client.SendCodeRequestAsync(tel);
        }

        public async Task EnterCode(string tel, string code)
        {
            user = await client.MakeAuthAsync(tel, hash, code);

            //var vachId = (await client.SearchUserAsync("JeremyAustin")).Users.Cast<TLUser>().FirstOrDefault(p => p.Username == "JeremyAustin").Id;
            //var lera = (await client.GetContactsAsync()).Users.Cast<TLUser>().FirstOrDefault(p => p.Phone == "79182682110");

            //var task = Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        var state = await client.GetUserDialogsAsync(limit:1000);
            //        //var histry = await client.GetHistoryAsync(new TLInputPeerUser { UserId = lera.Id, AccessHash = lera.AccessHash.Value }, limit: Int32.MaxValue, addOffset: 0, offsetId: 0);
            //        var dialogs = (state as TLDialogsSlice).Messages.Where(p => p is TLMessage).ToList().Cast<TLMessage>();
            //        var leraLastMessage = dialogs.Where(p => p.FromId == lera.Id).ToList();
            //        if (leraLastMessage.Any())
            //        {

            //        }
            //        await Task.Delay(500);
            //    }
            //});
        }

        public Dictionary<Account, bool> GetActualStatuses(IEnumerable<Account> accs)
        {
            var statuses = new Dictionary<Account, bool>();
            foreach (var acc in accs)
            {
                //client.
            }
            return statuses;
        }
    }
}
