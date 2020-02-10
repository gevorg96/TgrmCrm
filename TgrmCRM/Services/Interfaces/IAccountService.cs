using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IAccountService
    {
        public Task Add(Account entity);
        public Task Add(IEnumerable<Account> entities);
        public void Update(Account entity);
        public Task Delete(long id);
        public IEnumerable<Account> GetAll();
        public Account Get(long id);
        public IEnumerable<Account> Get(Func<Account, bool> criteria);
    }
}
