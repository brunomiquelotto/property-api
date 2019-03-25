using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis.Api.Cache;
using Redis.Api.Controllers.Base;
using Redis.Domain.Entities;
using Redis.Infra.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Redis.Api.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly PropertyRepository repository;
        private readonly JsonCache cache;

        public PropertyController(PropertyRepository repository, JsonCache cache)
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
            Property result = cache.GetObject<Property>("property:" + Id.ToString());
            if (result == null)
            {
                result = repository.FindWithUnities(Id);
                if (result == null)
                {
                    return NotFound();
                }
                cache.SetObject("property:" + Id.ToString(), result);
            }

            return result;
        }

        [HttpPost]
        public IActionResult Post(Property property)
        {
            repository.Add(property);
            return Ok();
        }
    }
}
