using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.Application.DTO.UserService
{
    public record RegisterUserDTO()
    {
        [Required] public string Login { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        [Required] public string UserName { get; set; } = null!;
        [Required] public string UserSurname { get; set; } = null!;
        public string UserPatronymic { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        [Required] public string UserPhone { get; set; } = null!;
        [Required] public DateOnly UserBirtdayDate { get; set; }
    }
}
