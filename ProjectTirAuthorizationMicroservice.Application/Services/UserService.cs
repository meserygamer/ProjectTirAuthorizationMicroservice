using ProjectTirAuthorizationMicroservice.Infrastructure.HashService;

namespace ProjectTirAuthorizationMicroservice.Application.Services
{
    public class UserService
    {
        public UserService(IPasswordHasher passwordHasher) 
        {
            _passwordHasher = passwordHasher;
        }


        private IPasswordHasher _passwordHasher;


        public async Task RegisterUser(string userName, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);


        }
    }
}
