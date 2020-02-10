using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services.Interfaces
{
    public interface IPartnerService
    {
        public Task Add(Partner entity);
        public Task Add(IEnumerable<Partner> entities);
        public void Update(Partner entity);
        public Task Delete(long id);
        public IEnumerable<Partner> GetAll();
        public Partner Get(long id);
        public IEnumerable<Partner> Get(Func<Partner, bool> criteria);
    }
}
