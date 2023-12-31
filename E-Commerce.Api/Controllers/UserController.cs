﻿using E_Commerce.Api._Base.Filters;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
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
        public async Task<IActionResult> Get(int id)
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

            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/User", data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateUserViewModel body, int id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.UpdateUser(body, id, loggedUser!);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            await _service.DeleteUser(id, loggedUser!);

            return NoContent();
        }
    }
}
