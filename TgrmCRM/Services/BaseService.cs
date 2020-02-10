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

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}
