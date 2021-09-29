﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using VimalJagruti.Domain.ViewModel.Common;

namespace VimalJagruti.Helper
{
    public class ModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = context.ModelState.Values.Select(c => c.Errors.First()?.ErrorMessage).FirstOrDefault()
                });
            }
        }
    }
}
