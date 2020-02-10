using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TLSchema;
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
