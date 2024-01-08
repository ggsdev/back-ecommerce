using E_Commerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Commerce.Api._Base.Filters
{
    public class AuthenticationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = context.HttpContext.Items["Id"];

            if (userId is null)
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    Message = Constants.NOT_LOGGED_USER
                });

                return;
            }

            await next();
        }
    }
}