using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.Application.DTO.UserService
{
    public record RegisterUserDTO()
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Минимальная длина логина - 5, максимальная - 30")]
        [RegularExpression(@"^[(A - Z)(a - z)(0 - 9)]+$", ErrorMessage = "Логин должен содержать только буквы английского алфавита и цифры")]
        public string Login { get; set; } = null!;

        [Required] 
        public string Password { get; set; } = null!;

        [Required] 
        public string UserName { get; set; } = null!;

        [Required] 
        public string UserSurname { get; set; } = null!;

        public string UserPatronymic { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        [Required] 
        public string UserPhone { get; set; } = null!;

        [Required] 
        public DateOnly UserBirtdayDate { get; set; }
    }
}
