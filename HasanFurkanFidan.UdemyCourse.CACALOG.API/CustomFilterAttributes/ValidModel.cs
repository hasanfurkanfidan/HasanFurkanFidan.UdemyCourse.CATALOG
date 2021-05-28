using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.CustomFilterAttributes
{
    public class ValidModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in context.ModelState.Values.FirstOrDefault().Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                var response = Response<NoContent>.Fail(errors, 404);
                
                context.Result = new ObjectResult(response)
                {
                    StatusCode = response.StatusCode,

                };
            }

        }
    }
}
