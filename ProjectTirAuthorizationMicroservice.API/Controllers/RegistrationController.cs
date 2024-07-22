using Microsoft.AspNetCore.Mvc;
using ProjectTirAuthorizationMicroservice.API.Contracts.Registration;
using System.ComponentModel.DataAnnotations;

namespace ProjectTirAuthorizationMicroservice.API.Controllers
{
    /// <summary>
    /// Контроллер механизма регистрации
    /// </summary>
    [Controller]
    [Route("[Controller]")]
    public class RegistrationController : Controller
    {
        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[Action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ValidationResult[]), 400)]
        public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
        {
            if (request is null)
                return BadRequest();

            if(!ValidateRegistrationRequest(request, out List<ValidationResult> results))
            {
                return BadRequest(results);
            }
            return Ok();
        }

        private bool ValidateRegistrationRequest(RegisterUserRequest request, out List<ValidationResult> results)
        {
            ValidationContext validation = new ValidationContext(request);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(request, validation, results, true);
        }
    }
}
