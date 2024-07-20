﻿using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using ProjectTirAuthorizationMicroservice.Core.DomainEntities;
using ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces;
using ProjectTirAuthorizationMicroservice.Infrastructure.HashService;
using ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService;

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


        public async Task RegisterUser(string userName, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);
        }

        public async Task Login(string login, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);

            DataConversionDTO<User> cachedUser = await _dataCacheService.GetCachedDataAsync<User>("users_login:" + login);
            if(!cachedUser.IsSuccessConversion)
            {

                return;
            }
            return;
        }
    }
}
