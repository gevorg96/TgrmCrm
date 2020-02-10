using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(TgrmDbContext db): base(db)
        { }

        public async Task Add(Contact entity)
        {
            await context.Contacts.AddAsync(entity);
        }

        public async Task Add(IEnumerable<Contact> entities)
        {
            await context.Contacts.AddRangeAsync(entities);
        }


        public void Update(Contact entity)
        {
            context.Contacts.Update(entity);
        }

        public async Task Delete(long id)
        {
            var acc = await context.Contacts.FindAsync(id);
            if (acc != null)
            {
                context.Contacts.Remove(acc);
            }
        }

        public Contact Get(long id)
        {
            return context.Contacts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Contact> Get(Func<Contact, bool> criteria)
        {
            return context.Contacts.Where(criteria).ToList();
        }

        public IEnumerable<Contact> GetAll()
        {
            return context.Contacts.ToList();
        }
    }
}
