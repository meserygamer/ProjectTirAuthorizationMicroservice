using Microsoft.EntityFrameworkCore;
using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces;
using ProjectTirAuthorizationMicroservice.Database.Entities;
using ProjectTirAuthorizationMicroservice.Database.Mappers;


namespace ProjectTirAuthorizationMicroservice.Database.Repositories
{
    public class UserRepositoryPgSQL : IUserRepository
    {
        public UserRepositoryPgSQL(ProjectTirAuthorizationMicroserviceDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        private readonly ProjectTirAuthorizationMicroserviceDbContext _dbContext;


        public async Task<User?> GetUserByLoginAsync(string login)
        {
            UserEntity? userEntity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login == login);

            if (userEntity == null) 
                return null;
            return new UserMapper().ToDomain(userEntity);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if(user is null)
                return false;

            try
            {
                await _dbContext.Users.AddAsync(new UserMapper().ToExternal(user));
                await _dbContext.SaveChangesAsync();
            }
            catch
            { 
                return false;
            }
            return true;
        }
    }
}
