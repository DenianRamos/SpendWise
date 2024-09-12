using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpendWise.Application.UseCase.Expenses.Register.User;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;

namespace SpendWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register
        ([FromServices] IRegisterUserUseCase UseCase, [FromBody] RequestRegisterUserJson request)
        {
            var response = await UseCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
