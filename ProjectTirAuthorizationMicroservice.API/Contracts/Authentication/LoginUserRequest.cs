using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.API.Contracts.Authentication
{
    public class LoginUserRequest
    {
        [Required] public string Login { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}
