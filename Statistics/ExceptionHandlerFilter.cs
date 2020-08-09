using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Statistics.Common;

namespace Statistics
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // all exceptions will be caught in this filter, which means all error handling will happen here.
            // In this case the StatisticException is caught and used for status code and result
            var exception = context.Exception;

            switch (exception)
            {
                case StatisticException statisticException:
                    context.Result = new JsonResult(statisticException.Message);
                    context.HttpContext.Response.StatusCode = statisticException.StatusCode;
                    break;
                default:
                    context.Result = new JsonResult("Unhandled exception");
                    break;
            }

            base.OnException(context);
        }
    }
}
