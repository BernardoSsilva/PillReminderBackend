using Microsoft.AspNetCore.Mvc;
using PillReminder.Communication.users.Requests;
using PillReminder.Communication.users.Responses;
using PillReminder.Comunication.users.Requests;
using PillReminder.Comunication.users.Responses;
using PillReminderApplication.UseCases.User.Get.Interfaces;
using PillReminderApplication.UseCases.User.Post.Interfaces;
using System.Xml.Linq;

namespace PillReminder.API.controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("/login")]
        [ProducesResponseType(typeof(UserAuthenticationResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserAuthenticationRequestJson requestBody, [FromServices] IAuthenticateUserUseCase useCase)
        {
            var response = await useCase.Execute(requestBody);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RegisterNewUser([FromBody] UserJsonRequest requestBody, [FromServices] IRegisterUserUseCase useCase) {

            var result = await useCase.Execute(requestBody);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(typeof(DetailedUserJsonResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindUserById(string userId, [FromServices] IGetUserByIdUseCase useCase)
        {
            var result = await useCase.Execute(userId);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(MultipleUserJsonResposne) ,StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAllUsers([FromServices] IListUsersUseCase useCase)
        {
            var result = await useCase.Execute();

            if(result.UsersList.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

      
    }
}
