using Microsoft.AspNetCore.Mvc;
using ProjectTirAuthorizationMicroservice.API.Contracts.Authentication;
using ProjectTirAuthorizationMicroservice.Application.Services;

namespace ProjectTirAuthorizationMicroservice.Controllers
{
    [Route("[Controller]")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController(UserService userService)
        {
            _userService = userService;
        }


        public UserService _userService;


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            await _userService.Login(request.Login, request.Password);
            return Ok("Login was confirmed");
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Logout()
        {
            return Ok($"Logout was confirmed");
        }
    }
}
