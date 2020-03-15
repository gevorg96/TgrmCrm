using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Services.Interfaces;
using TLSchema;
using TLSharp;

namespace TgrmCRM.Tgrm
{
    public class TgrmAuth
    {
        public static bool IsAuthentificated
        {
            get => client.IsUserAuthorized();
        }

        private IAccountService service;

        public TgrmAuth()
        {

        }

        public TgrmAuth(IAccountService service)
        {
            this.service = service;
        }

        public static Dictionary<TLUser, TelegramClient> clients = new Dictionary<TLUser, TelegramClient>();
        public static TelegramClient client = new TelegramClient(922350, "6a6dc6beb4825a7ae7bea7da57e17c63");
        private string hash;
        public static TLUser user;
        

        public async Task Auth(string tel)
        {
            try
            {
                client = new TelegramClient(922350, "6a6dc6beb4825a7ae7bea7da57e17c63", null, "general");
                await client.ConnectAsync();
                hash = await client.SendCodeRequestAsync(tel);
            }
            catch (Exception ex)
            {
                if (ex.Message == "AUTH_RESTART")
                {
                    await Task.Delay(1000);
                    await Auth(tel);
                }
            }

        }

        public async Task<(TelegramClient, string)?> AuthSecondary(string tel)
        {
            var authTelAcc = new TelegramClient(922350, "6a6dc6beb4825a7ae7bea7da57e17c63",null, tel + "_session");
            try
            {
                await authTelAcc.ConnectAsync();
                hash = await authTelAcc.SendCodeRequestAsync(tel);
                return (authTelAcc, hash);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateDbStatus()
        {
            if (clients.Count == 0)
            {
                foreach (var item in service.GetAll())
                {
                    item.isActive = false;
                    service.Update(item);
                }
            }
            else
            {
                var phones = clients.Keys.Cast<TLUser>().Select(p => p.Phone).ToList();
                foreach (var item in service.GetAll())
                {
                    if (!phones.Contains(item.Tels))
                    {
                        item.isActive = false;
                        service.Update(item);
                    }
                }
            }
        }

        public async Task EnterCodeSecondary(string tel, string code, TelegramClient cl, string hash)
        {
            try
            {
                var u = await cl.MakeAuthAsync(tel, hash, code);
                clients.Add(u, cl);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task EnterCode(string tel, string code)
        {
            user = await client.MakeAuthAsync(tel, hash, code);
        }
    }
}
