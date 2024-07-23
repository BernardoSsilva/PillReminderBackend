using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PillReminder.Communication.Exceptions;
using PillReminder.Exception.exceptions;

namespace PillReminder.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        // realiza chamada ao receber uma excessão
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AppExceptions)
            {
                // para erros tipados
                ThrowNewException(context);
            }
            else
            {
                // erros não tipados
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
