using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Services.Interfaces;
using System.Linq;
using TLSchema.Updates;
using TLSchema.Messages;
using System;

namespace TgrmCRM.Tgrm
{
    public static class RecieveUpdateJob
    {
        public static IAccountService accountService;
        public static IAnswerService answerService;
        public static IMessageAnswerService messageAnswerService;
        public static IThemeMessageService themeMessageService;
        public static Dictionary<long, TgrmAuth> tgrmAuths = new Dictionary<long, TgrmAuth>();

        public static TgrmAuth GetAccContext(long id)
        {
            return tgrmAuths[id];
        }

        public static void UpdateAccountStatus(long id, bool status)
        {
            var acc = accountService.Get(id);
            acc.isActive = status;
            accountService.Update(acc);
        }

        public static void Init(IAccountService _accountService, IAnswerService _answerService, IMessageAnswerService _messageAnswerService,
            IThemeMessageService _themeMessageService)
        {
            accountService = _accountService;
            answerService = _answerService;
            messageAnswerService = _messageAnswerService;
            themeMessageService = _themeMessageService;
            var accs = accountService.GetAll().Where(p => p.Role == 0).ToList();
            foreach (var acc in accs)
            {
                tgrmAuths.Add(acc.Id, new TgrmAuth());
            }
        }

        public static async Task CheckUpdates()
        {
            while (true)
            {
                //foreach (var acc in accountService.GetAll().Where(p => p.Role == 0))
                //{
                //    var contacts = themeMessageService.GetContactsFromAcc(acc);

                //    await Task.Run(() =>
                //    {

                //    });
                //    if (TgrmAuth.user != null)
                //    {
                //        var dialogs = await TgrmAuth.client.GetUserDialogsAsync(limit:Int32. MaxValue);
                //        var dgs = dialogs as TLDialogsSlice;
                //        //var target = dgs.Dialogs.FirstOrDefault(x => x.Peer as TL)
                //    }
                //}
            } 
        }
    }
}
