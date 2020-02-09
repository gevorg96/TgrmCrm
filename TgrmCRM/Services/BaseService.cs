using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgrmCRM.Entities;

namespace TgrmCRM.Services
{
    public abstract class BaseService
    {
        protected TgrmDbContext context;
        public BaseService(TgrmDbContext db)
        {
            context = db;
        }

        public abstract void Add(IEntity entity);
        public abstract void Add(IEnumerable<IEntity> entities);
        public abstract void Update(IEntity entity);
        public abstract void Delete(IEntity entity);
        public abstract IEnumerable<IEntity> GetAll();
        public abstract IEntity Get(long id);
        public abstract IEnumerable<IEntity> Get(Func<IEntity> criteria);
    }
}
