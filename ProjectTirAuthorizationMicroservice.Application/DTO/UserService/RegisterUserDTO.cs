using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.Application.DTO.UserService
{
    public record RegisterUserDTO()
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;
 
        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string UserPatronymic { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserPhone { get; set; } = null!;

        public DateOnly UserBirtdayDate { get; set; }
    }
}
