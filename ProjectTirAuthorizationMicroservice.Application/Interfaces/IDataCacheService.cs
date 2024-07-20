using ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService;

namespace ProjectTirAuthorizationMicroservice.Application.Interfaces
{
    public interface IDataCacheService
    {
        Task<CachedData<T>> GetCachedDataAsync<T>(string key, TimeSpan? updateExpireTime);
        Task<bool> CacheDataAsync<T>(string key, T data, TimeSpan? expireTime);
    }
}
