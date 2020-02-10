using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(TgrmDbContext db): base(db)
        { }

        public async Task Add(Account entity)
        {
            await context.Accounts.AddAsync(entity);
            await Commit();
        }

        public async Task Add(IEnumerable<Account> entities)
        {
            await context.Accounts.AddRangeAsync(entities);
            await Commit();
        }


        public void Update(Account entity)
        {
            context.Accounts.Update(entity);
            Commit().Wait();
        }

        public async Task Delete(long id)
        {
            var acc = await context.Accounts.FindAsync(id);
            if (acc != null)
            {
                context.Accounts.Remove(acc);
                await Commit();
            }
        }

        public Account Get(long id)
        {
            return context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Account> Get(Func<Account, bool> criteria)
        {
            return context.Accounts.Where(criteria).ToList();
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts.ToList();
        }
    }
}
