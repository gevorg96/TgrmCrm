using System.Threading.Tasks;
using TLSchema;
using TLSharp;

namespace TgrmCRM.Tgrm
{
    public static class TgrmAuth
    {
        public static bool IsAuthentificated
        {
            get => client.IsUserAuthorized();
        }

        private static TelegramClient client = new TelegramClient(922350, "6a6dc6beb4825a7ae7bea7da57e17c63");
        private static string hash;
        private static TLUser user;

        public async static Task Auth(string tel)
        {
            await client.ConnectAsync();
            hash = await client.SendCodeRequestAsync(tel);
        }

        public async static Task EnterCode(string tel, string code)
        {
            user = await client.MakeAuthAsync(tel, hash, code);
        }
    }
}
