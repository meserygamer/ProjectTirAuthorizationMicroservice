namespace ProjectTirAuthorizationMicroservice.Infrastructure.HashService
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Метод хэширования пароля под хранение в базе
        /// </summary>
        /// <param name="password">пароль для хэширования</param>
        /// <returns>Хэш-код пароля</returns>
        public string HashPassword(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        /// <summary>
        /// Проверяет соответсвует ли пароль хэшу
        /// </summary>
        /// <param name="password">пароль, для которого осуществляется проверка</param>
        /// <param name="hashedPassword">хэш пароля, которому проверяется соответсвие</param>
        /// <returns>Соответствие пароля хэшу</returns>
        public bool VerifyPassword(string? password, string? hashedPassword)
        {
            if(password is null || hashedPassword is null)
                return false;
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
