using Microsoft.Extensions.Configuration;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public class RedisCacheService : IDataCacheService
    {
        public RedisCacheService(IConfiguration configuration) 
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

        public async Task<DataConversionResult<T>> GetCachedData<T>(string key)
        {
            string? cachedString = await GetCachedStringAsync(key);
            if (cachedString is null)
                return new DataConversionResult<T>(false, default);
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(cachedString)))
                    return new DataConversionResult<T>(true, await JsonSerializer.DeserializeAsync<T>(ms));
            }   
            catch
            {
                return new DataConversionResult<T>(false, default);
            }
        }
    }
}
