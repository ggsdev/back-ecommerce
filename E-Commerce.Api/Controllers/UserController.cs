using E_Commerce.Api._Base.Filters;
using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterQuery queryParams)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var requestUrl = Request.GetEncodedUrl();
            var data = await _service.GetAllUsers(queryParams, requestUrl, loggedUser!);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.GetUserById(id, loggedUser!);

            return Ok(data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateUserViewModel body)
        {
            var data = await _service.CreateUser(body);

            return Created($"{Constants.ApiPrefix}/user", data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateUserViewModel body, long id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.UpdateUser(body, id, loggedUser!);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            await _service.DeleteUser(id, loggedUser!);

            return NoContent();
        }
    }
}
