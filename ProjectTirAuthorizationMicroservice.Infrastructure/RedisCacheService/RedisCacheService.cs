using Microsoft.Extensions.Configuration;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public class RedisCacheService : IDataCacheService
    {
        public RedisCacheService(IConfiguration configuration, TimeSpan? expireUpdateTime) 
        {
            _redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);
            _expireUpdateTime = expireUpdateTime;
        }


        private readonly ConnectionMultiplexer _redisConnection;
        private readonly TimeSpan? _expireUpdateTime;


        public async Task<bool> CacheStringAsync(string key, string value, TimeSpan expireTime)
        {
            IDatabase db = _redisConnection.GetDatabase();
            return await db.StringSetAsync(key, value, expireTime);
        }

        public async Task<string?> GetCachedStringAsync(string key)
        {
            IDatabase db = _redisConnection.GetDatabase();
            RedisValue redisValue = await db.StringGetAsync(key);
            if(_expireUpdateTime is not null)
                await db.KeyExpireAsync(key, _expireUpdateTime);
            return redisValue;
        }

        public async Task<DataConversionDTO<T>> GetCachedDataAsync<T>(string key)
        {
            string? cachedString = await GetCachedStringAsync(key);
            if (cachedString is null)
                return new DataConversionDTO<T>(false, default);
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(cachedString)))
                    return new DataConversionDTO<T>(true, await JsonSerializer.DeserializeAsync<T>(ms));
            }   
            catch
            {
                return new DataConversionDTO<T>(false, default);
            }
        }
    }
}
