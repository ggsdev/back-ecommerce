using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace E_Commerce.Api._Base.Middlewares
{
    public class AuthMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var authenticateResult = await context.AuthenticateAsync();

            if (authenticateResult.Succeeded && authenticateResult.Principal?.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim is not null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    context.Items["Id"] = userId;
                }
            }

            await _next(context);

            if (context.Response.StatusCode == 401 && !context.Response.HasStarted)
            {
                string? message = authenticateResult.Failure switch
                {
                    null => "Token is missing",
                    Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException => "Token has already expired",
                    _ => "Invalid JWT format for token",
                };

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync($"{{\"message\": \"{message}\"}}");
            }
        }
    }
}