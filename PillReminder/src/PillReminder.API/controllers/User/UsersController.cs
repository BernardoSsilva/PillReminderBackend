using Microsoft.AspNetCore.Mvc;
using PillReminder.Comunication.users.Requests;
using PillReminder.Comunication.users.Responses;
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
    }
}
