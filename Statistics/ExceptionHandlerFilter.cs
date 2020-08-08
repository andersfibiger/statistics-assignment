using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Statistics.Common;

namespace Statistics
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // all expcetions will be caught in this filter, which means all error handling will happen here.
            // In this case the StatisticExpcetion is caught and used for statuscode and result
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
