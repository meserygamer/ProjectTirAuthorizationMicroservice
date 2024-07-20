using ProjectTirAuthorizationMicroservice.Core.DomainEntities;

namespace ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByLoginAsync(string login);
    }
}
