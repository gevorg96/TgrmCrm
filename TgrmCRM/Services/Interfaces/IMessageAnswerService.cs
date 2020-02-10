using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IMessageAnswerService
    {
        public Task Add(MessageAnswer entity);
        public Task Add(IEnumerable<MessageAnswer> entities);
        public void Update(MessageAnswer entity);
        public Task Delete(long id);
        public IEnumerable<MessageAnswer> GetAll();
        public MessageAnswer Get(long id);
        public IEnumerable<MessageAnswer> Get(Func<MessageAnswer, bool> criteria);
    }
}
