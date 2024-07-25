using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PillReminder.Communication.Exceptions;
using PillReminder.Exception.exceptions;

namespace PillReminder.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        // call when recibes one exception
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AppExceptions)
            {
                // to typed errors
                ThrowNewException(context);
            }
            else
            {
                // to untyped errors
                ThrowUnknownException(context);
            }
        }

        private void ThrowNewException(ExceptionContext context)
        {
            var cashflowException = (AppExceptions)context.Exception;
            context.HttpContext.Response.StatusCode = cashflowException.statusCode;
            context.Result = new ObjectResult(cashflowException.getErrors());


        }
        private void ThrowUnknownException(ExceptionContext context)
        {
            var errorRespone = new ErrorMessageJson("Unknow Error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorRespone);
        }
    }
}
