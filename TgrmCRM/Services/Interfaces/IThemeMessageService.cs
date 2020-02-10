using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IThemeMessageService
    {
        public Task Add(ThemeMessage entity);
        public Task Add(IEnumerable<ThemeMessage> entities);
        public void Update(ThemeMessage entity);
        public Task Delete(long id);
        public IEnumerable<ThemeMessage> GetAll();
        public ThemeMessage Get(long id);
        public IEnumerable<ThemeMessage> Get(Func<ThemeMessage, bool> criteria);
    }
}
