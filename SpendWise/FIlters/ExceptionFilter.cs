using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpendWise.Communication.Responses;
using SpendWise.Exception;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Api.FIlters
{
    public class ExceptionFilter : IExceptionFilter

    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is SpendWiseException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var spendWiseException = context.Exception as SpendWiseException;
            var ErrorResponse = new ResponseErrorJson(spendWiseException.GetErrorList());
            context.HttpContext.Response.StatusCode = spendWiseException.StatusCode;
            context.Result = new ObjectResult(ErrorResponse);


        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }


    }
}
