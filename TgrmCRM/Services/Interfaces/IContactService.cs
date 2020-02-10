using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IContactService
    {
        public Task Add(Contact entity);
        public Task Add(IEnumerable<Contact> entities);
        public void Update(Contact entity);
        public Task Delete(long id);
        public IEnumerable<Contact> GetAll();
        public Contact Get(long id);
        public IEnumerable<Contact> Get(Func<Contact, bool> criteria);
    }
}
