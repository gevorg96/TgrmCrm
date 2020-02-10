using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IContactPartnerService
    {
        public Task Add(ContactPartner entity);
        public Task Add(IEnumerable<ContactPartner> entities);
        public void Update(ContactPartner entity);
        public Task Delete(long id);
        public IEnumerable<ContactPartner> GetAll();
        public ContactPartner Get(long id);
        public IEnumerable<ContactPartner> Get(Func<ContactPartner, bool> criteria);
    }
}
