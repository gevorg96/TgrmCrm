using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class ThemeMessageService : BaseService, IThemeMessageService
    {
        public ThemeMessageService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(ThemeMessage entity)
        {
            await context.ThemeMessages.AddAsync(entity);
        }

        public async Task Add(IEnumerable<ThemeMessage> entities)
        {
            await context.ThemeMessages.AddRangeAsync(entities);
        }

        public void Update(ThemeMessage entity)
        {
            context.ThemeMessages.Update(entity);
        }

        public async Task Delete(long id)
        {
            var acc = await context.ThemeMessages.FindAsync(id);
            if (acc != null)
            {
                context.ThemeMessages.Remove(acc);
            }
        }

        public ThemeMessage Get(long id)
        {
            return context.ThemeMessages.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ThemeMessage> Get(Func<ThemeMessage, bool> criteria)
        {
            return context.ThemeMessages.Where(criteria).ToList();
        }

        public IEnumerable<ThemeMessage> GetAll()
        {
            return context.ThemeMessages.ToList();
        }
    }
}

