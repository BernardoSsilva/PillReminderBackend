using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillReminder.Communication.remedies.requests;
using PillReminder.Communication.remedies.responses;
using PillReminderApplication.UseCases.Remedy.Delete.interfaces;
using PillReminderApplication.UseCases.Remedy.Get.interfaces;
using PillReminderApplication.UseCases.Remedy.Post.Interface;
using PillReminderApplication.UseCases.Remedy.Put.Interfaces;

namespace PillReminder.API.controllers.Remedy
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemediesController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateNewRemedyEndPoint([FromServices] ICreateNewRemedyUseCase useCase,[FromBody] RemedyJsonRequest requestBody, [FromHeader] string userToken ) {
            var response = await useCase.Execute(requestBody, userToken);

            if (response == null) {
                return BadRequest("Error on create");
            }

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(MultiplesRemediesJsonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> FindAllRemediesFromUserEndPoint([FromServices] IFindAllRemediesByUserUseCase useCase, [FromHeader] string userToken)
        {
            var response = await useCase.Execute(userToken);
            if(response.remedies.Count() == 0)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [Route("{remedyId}")]
        [HttpGet]
        [ProducesResponseType(typeof(RemedyDetailedJsonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindRemedyByIdEndPoint([FromServices] IFindRemedyByIdUseCase useCase, [FromHeader] string userToken, [FromRoute] string remedyId)
        {
            var response = await useCase.Execute(remedyId, userToken);
            if(response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [Route("{remedyId}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateRemedyEndPoint([FromServices] IUpdateRemedyUseCase useCase, [FromHeader] string userToken, [FromRoute] string remedyId, [FromBody] RemedyJsonRequest request)
        {
           
            await useCase.Execute(request, remedyId, userToken);

            return Ok();
        }

        [Route("{remedyId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteRemedyEndPoint([FromServices] IDeleteRemedyUseCase useCase, [FromHeader] string userToken, [FromRoute] string remedyId)
        {
            await useCase.Execute(remedyId, userToken);
            return Ok();
        }
    }
}
