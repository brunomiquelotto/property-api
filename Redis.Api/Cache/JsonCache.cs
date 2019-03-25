using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace Redis.Api.Cache
{
    public class JsonCache
    {
        public const int DEFAULT_CACHE_EXPIRATION = 2;
        private readonly IDistributedCache cache;

        public JsonCache(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public T GetObject<T>(string key)
        {
            string result = cache.GetString(key);
            if (result == null)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(result);
        }

        public void SetObject<T>(string key, T value, int minutesToExpiration = DEFAULT_CACHE_EXPIRATION)
        {
            string valueAsJson = JsonConvert.SerializeObject(value);
            cache.SetString(key, valueAsJson, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutesToExpiration) });
        }
    }
}
