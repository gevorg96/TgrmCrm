using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;
using TgrmCRM.Services.Interfaces;

namespace TgrmCRM.Services
{

    public class MessageAnswerService : BaseService, IMessageAnswerService
    {
        public MessageAnswerService(TgrmDbContext db) : base(db)
        { }

        public async Task Add(MessageAnswer entity)
        {
            await context.MessageAnswers.AddAsync(entity);
            Commit();
        }

        public async Task Add(IEnumerable<MessageAnswer> entities)
        {
            await context.MessageAnswers.AddRangeAsync(entities);
            Commit();
        }


        public void Update(MessageAnswer entity)
        {
            context.MessageAnswers.Update(entity);
            Commit();
        }

        public async Task Delete(long id)
        {
            var acc = await context.MessageAnswers.FindAsync(id);
            if (acc != null)
            {
                context.MessageAnswers.Remove(acc);
                Commit();
            }
        }

        public MessageAnswer Get(long id)
        {
            return context.MessageAnswers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<MessageAnswer> Get(Func<MessageAnswer, bool> criteria)
        {
            return context.MessageAnswers.Where(criteria).ToList();
        }

        public IEnumerable<MessageAnswer> GetAll()
        {
            return context.MessageAnswers.ToList();
        }
    }
}

