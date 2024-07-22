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


        public async Task<bool> RegisterUser(RegisterUserDTO request)
        {
            string hashedPassword = _passwordHasher.HashPassword(request.Password);

            if(await _userRepository.GetUserByLoginAsync(request.Login) is not null) //Проверяем есть ли пользователь с таким логином
                throw new ArgumentException("Login is busy");

            bool isUserRegistered = await _userRepository.AddUserAsync(new User
            {
                Login = request.Login,
                PasswordHash = hashedPassword,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Email = request.Email,
                Phone = request.Phone,
                BirthdayDate = request.BirthdayDate
            });
            User? registeredUser = await _userRepository.GetUserByLoginAsync(request.Login);
            if(registeredUser is not null)
                await _dataCacheService.CacheDataAsync(GetCacheKeyForUserByLogin(request.Login), registeredUser, TimeSpan.FromMinutes(2));
            return isUserRegistered;
        }

        public async Task<User?> Login(string login, string password)
        {
            string cacheKey = GetCacheKeyForUserByLogin(login);

            return await GetUserFromCacheByLoginPasswordPairAsync(login, password) ??       //Ищем данные в кэше, если их нет, идём в БД
                await GetUserFromDbByLoginPasswordPairWithCachingAsync(login, password);
        }

        private static string GetCacheKeyForUserByLogin(string login)
            => new StringBuilder("users_login:")
               .Append(login)
               .ToString();

        private async Task<User?> GetUserFromCacheByLoginPasswordPairAsync(string login, string password)
        {
            string cacheKey = GetCacheKeyForUserByLogin(login);

            CachedData<User> cachedUser = await _dataCacheService.GetCachedDataAsync<User>(cacheKey, new TimeSpan(0, 1, 0));

            if(!cachedUser.IsSuccessfulReceipt)
                return null;

            return (_passwordHasher.VerifyPassword(password, cachedUser.Value?.PasswordHash))? cachedUser.Value : null;
        }

        private async Task<User?> GetUserFromDbByLoginPasswordPairWithCachingAsync(string login, string password)
        {
            string cacheKey = GetCacheKeyForUserByLogin(login);

            User? userWithLogin = await _userRepository.GetUserByLoginAsync(login);
            if (userWithLogin is not null)
                await _dataCacheService.CacheDataAsync(cacheKey, (User)userWithLogin, new TimeSpan(0, 2, 0));

            return (_passwordHasher.VerifyPassword(password, userWithLogin?.PasswordHash))? userWithLogin : null;
        }
    }
}
