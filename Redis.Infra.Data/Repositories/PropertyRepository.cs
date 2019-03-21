using Redis.Domain.Entities;
using Redis.Domain.Repositories;
using Redis.Infra.Data.Context;
using Redis.Infra.Data.Repositories.Base;

namespace Redis.Infra.Data.Repositories
{
    public class PropertyRepository : Repository<Property>, IRepository<Property>
    {
        public PropertyRepository(AppContext context) : base(context)
        {

        }
    }
}
