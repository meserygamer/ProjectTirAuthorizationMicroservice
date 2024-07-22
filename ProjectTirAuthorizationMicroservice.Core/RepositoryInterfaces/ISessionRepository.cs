using ProjectTirAuthorizationMicroservice.Core.DomainEntities;

namespace ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces
{
    public interface ISessionRepository
    {
        Task<bool> AddSessionAsync(Session session);
    }
}
