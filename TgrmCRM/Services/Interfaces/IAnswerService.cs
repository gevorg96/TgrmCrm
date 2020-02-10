using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IAnswerService
    {
        public Task Add(Answer entity);
        public Task Add(IEnumerable<Answer> entities);
        public void Update(Answer entity);
        public Task Delete(long id);
        public IEnumerable<Answer> GetAll();
        public Answer Get(long id);
        public IEnumerable<Answer> Get(Func<Answer, bool> criteria);
    }
}
