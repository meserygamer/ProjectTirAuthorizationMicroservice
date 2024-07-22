using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces;
using ProjectTirAuthorizationMicroservice.Database.Entities;
using ProjectTirAuthorizationMicroservice.Database.Mappers;


namespace ProjectTirAuthorizationMicroservice.Database.Repositories
{
    public class SessionRepositoryPgSQL : ISessionRepository
    {
        public SessionRepositoryPgSQL(ProjectTirAuthorizationMicroserviceDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private readonly ProjectTirAuthorizationMicroserviceDbContext _dbContext;


        public async Task<bool> AddSessionAsync(Session session)
        {
            if(session is null)
                throw new ArgumentNullException(nameof(session));

            SessionEntity sessionEntity = new SessionMapper().ToExternal(session);
            try
            {
                await _dbContext.Sessions.AddAsync(sessionEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
