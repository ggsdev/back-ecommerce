using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class SessionController(ISessionService service) : ControllerBase
    {
        private readonly ISessionService _service = service;

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateSessionViewModel body)
        {
            var data = await _service.CreateSession(body);

            return Created("v1/api", data);
        }
    }
}
