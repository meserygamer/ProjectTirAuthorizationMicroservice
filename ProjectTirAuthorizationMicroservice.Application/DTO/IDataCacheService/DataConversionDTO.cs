namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public readonly record struct DataConversionDTO<T>(bool IsSuccessConversion, T? Value);
}
