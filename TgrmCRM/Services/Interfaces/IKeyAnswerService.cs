using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IKeyAnswerService
    {
        public Task Add(KeyAnswer entity);
        public Task Add(IEnumerable<KeyAnswer> entities);
        public void Update(KeyAnswer entity);
        public void Delete(long id);
        public IEnumerable<KeyAnswer> GetAll();
        public KeyAnswer Get(long id);
        public IEnumerable<KeyAnswer> Get(Func<KeyAnswer, bool> criteria);
    }
}
