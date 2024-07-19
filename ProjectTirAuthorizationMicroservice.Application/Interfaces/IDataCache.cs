namespace ProjectTirAuthorizationMicroservice.Application.Interfaces
{
    public interface IDataCache
    {
        Task<bool> CacheStringAsync(string key, string value, TimeSpan expireTime);
        Task<string?> GetCachedStringAsync(string key);
    }
}
