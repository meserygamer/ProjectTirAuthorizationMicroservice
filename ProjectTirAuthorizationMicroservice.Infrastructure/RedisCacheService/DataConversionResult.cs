namespace ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService
{
    public readonly record struct DataConversionResult<T>(bool IsSuccessConversion, T? Value);
}
