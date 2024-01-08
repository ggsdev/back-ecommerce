using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
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
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Post(CreateUpdateCategoryViewModel body)
        {
            var data = await _service.CreateCategory(body);

            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/{nameof(Category)}", data);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Put(CreateUpdateCategoryViewModel body, int id)
        {
            var data = await _service.UpdateCategory(body, id);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCategory(id);

            return NoContent();
        }
    }
}
