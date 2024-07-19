using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Database.Entities;

namespace ProjectTirAuthorizationMicroservice.Database.Mappers
{
    public class UserMapper : IMapper<UserEntity, User>
    {
        public User ToDomain(UserEntity externalEntity)
        {
            var domainUser = new User
            {
                Id = externalEntity.Id,
                Login = externalEntity.Login,
                PasswordHash = externalEntity.PasswordHash,
                UserName = externalEntity.UserName,
                UserSurname = externalEntity.UserSurname,
                UserPatronymic = externalEntity.UserPatronymic,
                UserEmail = externalEntity.UserEmail,
                UserPhone = externalEntity.UserPhone,
                UserBirtdayDate = externalEntity.UserBirtdayDate,
            };
            return domainUser;
        }

        public UserEntity ToExternal(UserEntity domainEntity)
        {
            var externalUser = new UserEntity
            {
                Id = domainEntity.Id,
                Login = domainEntity.Login,
                PasswordHash = domainEntity.PasswordHash,
                UserName = domainEntity.UserName,
                UserSurname = domainEntity.UserSurname,
                UserPatronymic = domainEntity.UserPatronymic,
                UserEmail = domainEntity.UserEmail,
                UserPhone = domainEntity.UserPhone,
                UserBirtdayDate = domainEntity.UserBirtdayDate,
            };
            return externalUser;
        }
    }
}
