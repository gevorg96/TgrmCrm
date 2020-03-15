using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Tgrm;
using TLSchema;
using Xunit;

namespace TgrmCRM.Tests
{
    public class TrgmCrmTests
    {
        private TgrmAuth auth;
        [Fact]
        public async Task TestTgrmCrmAuth()
        {
            auth = new TgrmAuth();
            var telephone = "79649073353";
            await auth.Auth(telephone);

            string code = "77910";
            await auth.EnterCode(telephone, code);

        }

        //[Fact]
        //public async Task TestTgrmSendMessage()
        //{
        //    //1021532854
        //    await TestTgrmCrmAuth();
        //    //await auth.client.SendMessageAsync(new TLInputPeerUser() { UserId = 1021532854 }, "2112");
        //    var users = await auth.client.SearchUserAsync("@linaa_smm");
        //    var u = users.Users.ToList().First();
        //}
    }
}
