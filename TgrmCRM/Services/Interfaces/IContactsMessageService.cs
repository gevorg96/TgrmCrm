using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IContactsMessageService
    {
        public Task Add(ContactsMessages entity);
        public Task Add(IEnumerable<ContactsMessages> entities);
        public void Update(ContactsMessages entity);
        public Task Delete(long id);
        public IEnumerable<ContactsMessages> GetAll();
        public ContactsMessages Get(long id);
        public IEnumerable<ContactsMessages> Get(Func<ContactsMessages, bool> criteria);
    }
}
