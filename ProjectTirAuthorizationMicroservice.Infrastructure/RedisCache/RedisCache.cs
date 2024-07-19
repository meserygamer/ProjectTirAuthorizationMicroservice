using Microsoft.Extensions.Configuration;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using StackExchange.Redis;

namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCache
{
    public class RedisCache : IDataCache
    {
        public RedisCache(IConfiguration configuration) 
        {
            _redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);
        }


        private readonly ConnectionMultiplexer _redisConnection;


        public async Task<bool> CacheStringAsync(string key, string value, TimeSpan expireTime)
        {
            IDatabase db = _redisConnection.GetDatabase();
            return await db.StringSetAsync(key, value, expireTime);
        }

        public async Task<string?> GetCachedStringAsync(string key)
        {
            IDatabase db = _redisConnection.GetDatabase();
            return await db.StringGetAsync(key);
        }
    }
}
