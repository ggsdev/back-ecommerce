using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.ControlAccess.Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAll();

            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(long id)
        {
            var data = await _service.GetById(id);

            return Ok(data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserCreateViewModel body)
        {
            var data = await _service.Create(body);

            return Ok(data);
        }
    }
}
