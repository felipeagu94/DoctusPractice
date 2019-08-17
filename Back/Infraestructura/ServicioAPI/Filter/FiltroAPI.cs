using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServicioAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioAPI.Filter
{
    public class FiltroAPI : IExceptionFilter, IResultFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new ResponseModel { Code = 500, Data = context.Exception.Message });
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result.GetType() != typeof(BadRequestObjectResult))
            {
                var jsonResult = context.Result as JsonResult;
                context.Result = new JsonResult(new ResponseModel { Code = 200, Data = jsonResult.Value });
            }
        }
    }
}
