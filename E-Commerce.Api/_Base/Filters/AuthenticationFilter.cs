using E_Commerce.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api._Base.Filters
{
    public class AuthenticationFilter(DataContext context) : IAsyncActionFilter
    {
        private readonly DataContext _context = context;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = context.HttpContext.Items["Id"] as int?;

            if (userId is int)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Id == userId);

                if (user is null)
                {
                    context.Result = new UnauthorizedObjectResult(new
                    {
                        Message = "User not identified, please login first"
                    });

                    return;
                }

                context.HttpContext.Items["User"] = user;

            }

            await next();
        }
    }
}