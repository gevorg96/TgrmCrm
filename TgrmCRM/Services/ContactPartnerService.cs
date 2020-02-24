using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class ContactPartnerService : BaseService, IContactPartnerService
    {
        public ContactPartnerService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(ContactPartner entity)
        {
            await context.ContactPartners.AddAsync(entity);
            Commit();
        }

        public async Task Add(IEnumerable<ContactPartner> entities)
        {
            await context.ContactPartners.AddRangeAsync(entities);
            Commit();
        }


        public void Update(ContactPartner entity)
        {
            context.ContactPartners.Update(entity);
            Commit();
        }

        public async Task Delete(long id)
        {
            var acc = await context.ContactPartners.FindAsync(id);
            if (acc != null)
            {
                context.ContactPartners.Remove(acc);
                Commit();
            }
        }

        public ContactPartner Get(long id)
        {
            return context.ContactPartners.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ContactPartner> Get(Func<ContactPartner, bool> criteria)
        {
            return context.ContactPartners.Where(criteria).ToList();
        }

        public IEnumerable<ContactPartner> GetAll()
        {
            return context.ContactPartners.ToList();
        }
    }
}
