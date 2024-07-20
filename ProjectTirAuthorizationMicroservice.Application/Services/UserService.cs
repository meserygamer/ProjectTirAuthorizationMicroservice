using ProjectTirAuthorizationMicroservice.Application.DTO.UserService;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces;
using ProjectTirAuthorizationMicroservice.Infrastructure.HashService;
using ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService;
using System.Text;

namespace ProjectTirAuthorizationMicroservice.Application.Services
{
    public class UserService
    {
        public UserService(IPasswordHasher passwordHasher,
            IDataCacheService dataCacheService,
            IUserRepository userRepository) 
        {
            _passwordHasher = passwordHasher;
            _dataCacheService = dataCacheService;
            _userRepository = userRepository;
        }


        private readonly IPasswordHasher _passwordHasher;
        private readonly IDataCacheService _dataCacheService;
        private readonly IUserRepository _userRepository;


        public async Task RegisterUser(RegisterUserDTO request)
        {
            string hashedPassword = _passwordHasher.HashPassword(request.Password);
        }

        public async Task<User?> Login(string login, string password)
        {
            string cacheKey = new StringBuilder("users_login:")
                .Append(login)
                .ToString();

            CachedData<User> cachedUser = await _dataCacheService.GetCachedDataAsync<User>(cacheKey, new TimeSpan(0, 5, 0));
            if(cachedUser.IsSuccessConversion)
            {
                if(cachedUser.Value is null)
                    return null;

                if(!_passwordHasher.VerifyPassword(password, cachedUser.Value.PasswordHash))
                    return null;

                return cachedUser.Value;
            }

            User? userWithLogin = await _userRepository.GetUserByLoginAsync(login);
            if (userWithLogin is null)
                return null;

            await _dataCacheService.CacheDataAsync(cacheKey, (User)userWithLogin, new TimeSpan(0, 10, 0));

            if (!_passwordHasher.VerifyPassword(password, userWithLogin.PasswordHash))
                return null;

            return userWithLogin;
        }
    }
}
