using ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService;

namespace ProjectTirAuthorizationMicroservice.Application.Interfaces
{
    public interface IDataCacheService
    {
        Task<bool> CacheStringAsync(string key, string value, TimeSpan expireTime);
        Task<string?> GetCachedStringAsync(string key);
        Task<DataConversionDTO<T>> GetCachedDataAsync<T>(string key);
    }
}
