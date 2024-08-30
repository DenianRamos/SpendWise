using Microsoft.AspNetCore.Mvc;
using SpendWise.Application.UseCase.Expenses.Register;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using SpendWise.Application.UseCase.Expenses.GetAll;
using SpendWise.Application.UseCase.Expenses.GetById;
using SpendWise.Application.UseCase.Expenses.Delete;
using SpendWise.Application.UseCase.Expenses.Update;


namespace SpendWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendWiseController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public  async Task <IActionResult> Register([FromBody] RequestExpenseJson request, [FromServices] IRegisterExpenseUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponsesExpensesJson), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpenseUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Expenses.Count != 0) 
                return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetExpenseById([FromRoute] long id, [FromServices] IGetExpenseByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);
            return Ok(response);

            
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] IDeleteExpenseUseCase useCase)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] RequestExpenseJson request, [FromServices] IUpdateExpenseUseCase useCase)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }


        


    }
}
