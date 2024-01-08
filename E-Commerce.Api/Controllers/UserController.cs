using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterQuery queryParams)
        {
            var requestUrl = Request.GetEncodedUrl();

            var data = await _service.GetAllUsers(queryParams, requestUrl);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetUserById(id);

            return Ok(data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateUserViewModel body)
        {
            var data = await _service.CreateUser(body);

            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/{nameof(Domain.ControlAccess.Users.Entities.User)}", data);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Put(UpdateUserViewModel body, int id)
        {
            var data = await _service.UpdateUser(body, id);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUser(id);

            return NoContent();
        }
    }
}
