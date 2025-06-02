using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace social_events_manager.Middlewares;

public class ModelStateValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            // List<string> list = (
            //     from modelState in context.ModelState.Values
            //     from error in modelState.Errors
            //     select error.ErrorMessage
            // ).ToList();
            // context.Result = new BadRequestObjectResult(list);

            context.Result = new BadRequestObjectResult(context.ModelState);
        }

        base.OnActionExecuting(context);
    }
}
