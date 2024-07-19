using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Database.Entities;

namespace ProjectTirAuthorizationMicroservice.Database.Mappers
{
    public class SessionMapper : IMapper<SessionEntity, Session>
    {
        public Session ToDomain(SessionEntity externalEntity)
        {
            var domainSession = new Session
            {
                Id = externalEntity.Id,
                StartDate = externalEntity.StartDate,
                UserId = externalEntity.UserId
            };
            return domainSession;
        }

        public SessionEntity ToExternal(SessionEntity domainEntity)
        {
            var externalSession = new SessionEntity
            {
                Id = domainEntity.Id,
                StartDate = domainEntity.StartDate,
                UserId = domainEntity.UserId,
            };
            return externalSession;
        }
    }
}
