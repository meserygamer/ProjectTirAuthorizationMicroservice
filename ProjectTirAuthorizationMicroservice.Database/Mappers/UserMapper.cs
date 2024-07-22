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
                Name = externalEntity.Name,
                Surname = externalEntity.Surname,
                Patronymic = externalEntity.Patronymic,
                Email = externalEntity.Email,
                Phone = externalEntity.Phone,
                BirthdayDate = externalEntity.BirthdayDate,
            };
            return domainUser;
        }

        public UserEntity ToExternal(User domainEntity)
        {
            var externalUser = new UserEntity
            {
                Id = domainEntity.Id,
                Login = domainEntity.Login,
                PasswordHash = domainEntity.PasswordHash,
                Name = domainEntity.Name,
                Surname = domainEntity.Surname,
                Patronymic = domainEntity.Patronymic,
                Email = domainEntity.Email,
                Phone = domainEntity.Phone,
                BirthdayDate = domainEntity.BirthdayDate,
            };
            return externalUser;
        }
    }
}
