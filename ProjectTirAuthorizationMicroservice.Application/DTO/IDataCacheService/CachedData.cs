namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public record CachedData<T>(bool IsSuccessConversion, T? Value);
}
