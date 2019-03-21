using Redis.Api.Controllers.Base;
using Redis.Domain.Entities;
using Redis.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Api.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly PropertyRepository repository;

        public PropertyController(PropertyRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Property> Get()
        {
            return repository.Get();
        }
    }
}
