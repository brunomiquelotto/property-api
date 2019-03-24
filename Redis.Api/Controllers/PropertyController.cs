using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis.Api.Controllers.Base;
using Redis.Domain.Entities;
using Redis.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Api.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly PropertyRepository repository;
        private readonly IDistributedCache cache;

        public PropertyController(PropertyRepository repository, IDistributedCache cache)
        {
            this.repository = repository;
            this.cache = cache;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return repository.PropertyWithUnities();
        }

        [HttpGet("{Id}")]
        public ActionResult<Property> Get(Guid Id)
        {
            string result = cache.GetString("property:" + Id.ToString());
            if (result == null)
            {
                Property property = repository.FindWithUnities(Id);
                if (property == null)
                {
                    return NotFound();
                }

                result = JsonConvert.SerializeObject(property);
                cache.SetString("property:" + Id.ToString(), result, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(120) });
            }

            return JsonConvert.DeserializeObject<Property>(result);
        }

        [HttpPost]
        public IActionResult Post(Property property)
        {
            repository.Add(property);
            return Ok();
        }
    }
}
