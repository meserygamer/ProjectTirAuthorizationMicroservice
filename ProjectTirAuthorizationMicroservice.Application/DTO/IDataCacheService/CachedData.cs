namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public record CachedData<T>(bool IsSuccessfulReceipt, T? Value);
}
