﻿using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.DTOs.ViewModels.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.ControlAccess.Sessions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController(ISessionService service) : ControllerBase
    {
        private readonly ISessionService _service = service;

        [HttpPost]
        public async Task<IActionResult> Post(CreateSessionViewModel body)
        {
            var data = await _service.CreateSession(body);

            return Ok(data);
        }
    }
}