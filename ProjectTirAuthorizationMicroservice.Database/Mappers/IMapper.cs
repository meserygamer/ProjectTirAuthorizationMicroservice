namespace ProjectTirAuthorizationMicroservice.Database.Mappers
{
    public interface IMapper<E, D>
    {
        D ToDomain(E externalEntity);

        E ToExternal(E domainEntity);
    }
}
