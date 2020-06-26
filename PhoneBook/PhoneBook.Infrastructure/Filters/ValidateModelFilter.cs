using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace PhoneBook.Infrastructure.Filters
{
    public class ValidateModelFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
                context.Result = new BadRequestObjectResult(error);
            }
        }
    }
}
