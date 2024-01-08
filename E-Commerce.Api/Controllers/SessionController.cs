using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
    public class SessionController(ISessionService service) : ControllerBase
    {
        private readonly ISessionService _service = service;

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateSessionViewModel body)
        {
            var data = await _service.CreateSession(body);

            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/{nameof(Session)}", data);
        }
    }
}
