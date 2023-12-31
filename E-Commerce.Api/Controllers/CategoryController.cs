﻿using E_Commerce.Api._Base.Filters;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        private readonly ICategoryService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterQuery queryParams)
        {
            var requestUrl = Request.GetEncodedUrl();
            var data = await _service.GetAllCategories(queryParams, requestUrl);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var data = await _service.GetCategoryById(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUpdateCategoryViewModel body)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.CreateCategory(body, loggedUser!);


            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/Category", data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateUpdateCategoryViewModel body, int id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.UpdateCategory(body, id, loggedUser!);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            await _service.DeleteCategory(id, loggedUser!);

            return NoContent();
        }
    }
}
