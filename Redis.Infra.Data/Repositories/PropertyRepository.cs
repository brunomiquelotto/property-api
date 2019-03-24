using Microsoft.EntityFrameworkCore;
using Redis.Domain.Entities;
using Redis.Domain.Repositories;
using Redis.Infra.Data.Context;
using Redis.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Redis.Infra.Data.Repositories
{
    public class PropertyRepository : Repository<Property>, IRepository<Property>
    {
        public PropertyRepository(ApplicationContext context) : base(context)
        {

        }

        public IEnumerable<Property> PropertyWithUnities()
        {
            return this.Context.Properties.Include(p => p.Unities);
        }

        public Property FindWithUnities(Guid id)
        {
            return this.Context.Properties.Include(p => p.Unities).FirstOrDefault(p => p.Id == id);
        }
    }
}
