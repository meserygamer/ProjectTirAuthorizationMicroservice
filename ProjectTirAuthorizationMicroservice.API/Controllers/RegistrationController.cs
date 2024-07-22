using Microsoft.AspNetCore.Mvc;
using ProjectTirAuthorizationMicroservice.API.Contracts.Registration;
using ProjectTirAuthorizationMicroservice.Application.DTO.UserService;
using ProjectTirAuthorizationMicroservice.Application.Services;
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
        public RegistrationController(UserService userService) 
        {
            _userService = userService;
        }


        private UserService _userService;


        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="request">Данные пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[Action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            if (request is null)
                return BadRequest("Request body was incorrect");

            if(!ValidateRegistrationRequest(request, out List<ValidationResult> results))
                return BadRequest(results.Select(item => item.ErrorMessage));

            bool isUserWasCreated;
            try
            {
                isUserWasCreated = await _userService.RegisterUser(new RegisterUserDTO()
                {
                    Login = request.Login,
                    Password = request.Password,
                    UserName = request.UserName,
                    UserSurname = request.UserSurname,
                    UserPatronymic = request.UserPatronymic,
                    UserEmail = request.UserEmail,
                    UserPhone = request.UserPhone,
                    UserBirtdayDate = request.UserBirtdayDate
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            if (isUserWasCreated)
                return Ok(); //
            return StatusCode(500);
        }

        private bool ValidateRegistrationRequest(RegisterUserRequest request, out List<ValidationResult> results)
        {
            ValidationContext validation = new ValidationContext(request);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(request, validation, results, true);
        }
    }
}
