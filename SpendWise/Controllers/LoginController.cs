using Microsoft.AspNetCore.Mvc;
using SpendWise.Application.UseCase.Login;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;

namespace SpendWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login
        ([FromServices] ILoginUseCase UseCase, [FromBody] RequestLoginJson request)
        {
            var response = await UseCase.Execute(request);

            return Ok(response);
        }
    }
}
