using E_Commerce.Shared;
using E_Commerce.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api._Base
{
    [Route(Constants.ApiPrefixFirstVersion + "/[controller]")]
    public class HealthCheckController(DataContext dbContext) : ControllerBase
    {
        private readonly DataContext _dbContext = dbContext;

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHealth()
        {
            var versiond = typeof(HealthCheckController).Assembly.GetName().Version?.ToString();
            try
            {
                var safe = await _dbContext.Database.CanConnectAsync();
                if (safe is false)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Problema ao se conectar com o banco de dados", Version = versiond, ConnectedToDatabase = false });

                return Ok(new { Message = "API saudável", Version = versiond, ConnectedToDatabase = true });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Problema ao se conectar com o banco de dados", Version = versiond, ConnectedToDatabase = false });
            }
        }
    }
}
