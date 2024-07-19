using Microsoft.AspNetCore.Mvc;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;

namespace ProjectTirAuthorizationMicroservice.Controllers
{
    [Route("[Controller]")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController(IDataCache dataCache)
        {
            _dataCache = dataCache;
        }


        private readonly IDataCache _dataCache;


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login()
        {
            await _dataCache.CacheStringAsync("User", "Was confirmed", new TimeSpan(0, 0, 15));
            return Ok("Login was confirmed");
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Logout()
        {
            string? user = await _dataCache.GetCachedStringAsync("User");
            return Ok($"Logout was confirmed, Redis say - {user}");
        }
    }
}
