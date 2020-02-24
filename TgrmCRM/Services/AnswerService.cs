using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{
    public class AnswerService : BaseService, IAnswerService
    {
        public AnswerService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(Answer entity)
        {
            await context.Answers.AddAsync(entity);
            Commit();
        }

        public async Task Add(IEnumerable<Answer> entities)
        {
            await context.Answers.AddRangeAsync(entities);
            Commit();
        }


        public void Update(Answer entity)
        {
            context.Answers.Update(entity);
            Commit();
        }

        public async Task Delete(long id)
        {
            var acc = await context.Answers.FindAsync(id);
            if (acc != null)
            {
                context.Answers.Remove(acc);
                Commit();
            }
        }

        public Answer Get(long id)
        {
            return context.Answers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Answer> Get(Func<Answer, bool> criteria)
        {
            return context.Answers.Where(criteria).ToList();
        }

        public IEnumerable<Answer> GetAll()
        {
            return context.Answers.ToList();
        }
    }
}
