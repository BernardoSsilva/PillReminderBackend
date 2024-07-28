using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> registerNewUser([FromBody] UserJsonRequest requestBody, [FromServices] IRegisterUserUseCase useCase) {

            var result = await useCase.Execute(requestBody);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(MultipleUserJsonResposne) ,StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> findAllUsers([FromServices] IListUsersUseCase useCase)
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
