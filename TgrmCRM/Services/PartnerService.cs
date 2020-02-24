using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{

    public class PartnerService : BaseService, IPartnerService
    {
        public PartnerService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(Partner entity)
        {
            await context.Partners.AddAsync(entity);
            Commit();
        }

        public async Task Add(IEnumerable<Partner> entities)
        {
            await context.Partners.AddRangeAsync(entities);
            Commit();
        }

        public void Update(Partner entity)
        {
            context.Partners.Update(entity);
            Commit();
        }

        public async Task Delete(long id)
        {
            var acc = await context.Partners.FindAsync(id);
            if (acc != null)
            {
                context.Partners.Remove(acc);
                Commit();
            }
        }

        public Partner Get(long id)
        {
            return context.Partners.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Partner> Get(Func<Partner, bool> criteria)
        {
            return context.Partners.Where(criteria).ToList();
        }

        public IEnumerable<Partner> GetAll()
        {
            return context.Partners.ToList();
        }
    }
}

