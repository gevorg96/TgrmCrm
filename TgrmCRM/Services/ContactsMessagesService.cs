using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{

    public class ContactsMessagesService : BaseService, IContactsMessageService
    {
        public ContactsMessagesService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(ContactsMessages entity)
        {
            await context.ContactsMessages.AddAsync(entity);
        }

        public async Task Add(IEnumerable<ContactsMessages> entities)
        {
            await context.ContactsMessages.AddRangeAsync(entities);
        }


        public void Update(ContactsMessages entity)
        {
            context.ContactsMessages.Update(entity);
        }

        public async Task Delete(long id)
        {
            var acc = await context.ContactsMessages.FindAsync(id);
            if (acc != null)
            {
                context.ContactsMessages.Remove(acc);
            }
        }

        public ContactsMessages Get(long id)
        {
            return context.ContactsMessages.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ContactsMessages> Get(Func<ContactsMessages, bool> criteria)
        {
            return context.ContactsMessages.Where(criteria).ToList();
        }

        public IEnumerable<ContactsMessages> GetAll()
        {
            return context.ContactsMessages.ToList();
        }
    }
}

