using Microsoft.AspNetCore.Mvc;

namespace ProjectTirAuthorizationMicroservice.Controllers
{
    [Route("[Controller]")]
    public class AuthenticationController : Controller
    {
        
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login()
        {
            return Ok("Login was confirmed");
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Logout()
        {
            return Ok("Logout was confirmed");
        }
    }
}
