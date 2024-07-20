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


        public async Task<CachedData<T>> GetCachedDataAsync<T>(string key, TimeSpan? updateExpireTime)
        {
            string? cachedString = await GetCachedStringAsync(key, updateExpireTime);
            if (cachedString is null)
                return new CachedData<T>(false, default);
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(cachedString)))
                    return new CachedData<T>(true, await JsonSerializer.DeserializeAsync<T>(ms));
            }   
            catch
            {
                return new CachedData<T>(false, default);
            }
        }

        public async Task<bool> CacheDataAsync<T>(string key, T data, TimeSpan? expireTime = null)
        {
            string? dataInJsonForm;
            try
            {
                using (MemoryStream ms = new())
                {
                    await JsonSerializer.SerializeAsync(ms, data, typeof(T));
                    dataInJsonForm = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return false;
            }
            await CacheStringAsync(key, dataInJsonForm, expireTime);
            return true;
        }

        private async Task<bool> CacheStringAsync(string key, string value, TimeSpan? expireTime = null)
        {
            IDatabase db = _redisConnection.GetDatabase();
            return await db.StringSetAsync(key, value, expireTime);
        }

        private async Task<string?> GetCachedStringAsync(string key, TimeSpan? updateExpireTime)
        {
            IDatabase db = _redisConnection.GetDatabase();
            RedisValue redisValue = await db.StringGetAsync(key);
            if (updateExpireTime is not null)
                await db.KeyExpireAsync(key, updateExpireTime);
            return redisValue;
        }
    }
}
