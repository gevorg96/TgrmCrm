using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class KeyAnswerService : BaseService, IKeyAnswerService
    {
        public KeyAnswerService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(KeyAnswer entity)
        {
            await context.KeyAnswers.AddAsync(entity);
            Commit();
        }

        public async Task Add(IEnumerable<KeyAnswer> entities)
        {
            await context.KeyAnswers.AddRangeAsync(entities);
            Commit();
        }


        public void Update(KeyAnswer entity)
        {
            context.KeyAnswers.Update(entity);
            Commit();
        }

        public async Task Delete(long id)
        {
            var acc = await context.KeyAnswers.FindAsync(id);
            if (acc != null)
            {
                context.KeyAnswers.Remove(acc);
                Commit();
            }
        }

        public KeyAnswer Get(long id)
        {
            return context.KeyAnswers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<KeyAnswer> Get(Func<KeyAnswer, bool> criteria)
        {
            return context.KeyAnswers.Where(criteria).ToList();
        }

        public IEnumerable<KeyAnswer> GetAll()
        {
            return context.KeyAnswers.ToList();
        }
    }
}
