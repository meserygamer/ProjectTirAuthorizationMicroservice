using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.Application.DTO.UserService
{
    public record RegisterUserDTO()
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;
 
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly BirthdayDate { get; set; }
    }
}
