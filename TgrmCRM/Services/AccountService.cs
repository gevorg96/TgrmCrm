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
            Commit();
        }

        public async Task Add(IEnumerable<Account> entities)
        {
            await context.Accounts.AddRangeAsync(entities);
            Commit();
        }


        public void Update(Account entity)
        {
            context.Accounts.Update(entity);
            Commit();
        }

        public void Delete(long id)
        {
            var acc = context.Accounts.FirstOrDefault(p => p.Id == id);
            if (acc != null)
            {
                context.Accounts.Remove(acc);
                Commit();
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
