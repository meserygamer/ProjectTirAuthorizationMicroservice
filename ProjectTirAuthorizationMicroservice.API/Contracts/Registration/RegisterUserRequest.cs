using ProjectTirAuthorizationMicroservice.Infrastructure.JsonConverters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectTirAuthorizationMicroservice.API.Contracts.Registration
{
    [Serializable]
    public class RegisterUserRequest
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Минимальная длина логина - 5, максимальная - 30")]
        [RegularExpression(@"^[(A-Z)(a-z)(0-9)]+$",
            ErrorMessage = "Логин должен содержать только буквы английского алфавита и цифры")]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Минимальная длина пароля - 6, максимальная - 30")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)[(A-Z)(a-z)(\d)(@$!%*?&)]+$",
            ErrorMessage = "Пароль должен содержать: хотя бы одну заглавную букву; хотя бы одну строчную букву; хотя бы одну цифру")]
        public string Password { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string UserSurname { get; set; } = null!;

        public string UserPatronymic { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Некорректный Email")]
        public string UserEmail { get; set; } = null!;

        [Required]
        [Phone]
        public string UserPhone { get; set; } = null!;

        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly UserBirtdayDate { get; set; }
    }
}
