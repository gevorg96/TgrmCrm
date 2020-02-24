using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;
using System.Linq;

namespace TgrmCRM.Tgrm
{
    public class RecieveUpdateJob
    {
        private readonly IAccountService accountService;
        private readonly IAnswerService answerService;
        private readonly IMessageAnswerService messageAnswerService;
        private readonly IThemeMessageService themeMessageService;

        public RecieveUpdateJob(IAccountService accountService, IAnswerService answerService, IMessageAnswerService messageAnswerService,
            IThemeMessageService themeMessageService)
        {
            this.accountService = accountService;
            this.answerService = answerService;
            this.messageAnswerService = messageAnswerService;
            this.themeMessageService = themeMessageService;
        }


        public async Task CheckUpdates()
        {
            while (true)
            {
                foreach(var acc in accountService.GetAll())
                {
                    var contacts = themeMessageService.GetContactsFromAcc(acc);

                    await Task.Run(() => 
                    { 
                        
                    });
                }
            } 
        }
    }
}
