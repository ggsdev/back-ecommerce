using E_Commerce.Api._Base.Filters;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.SubCategories.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.ApiPrefixFirstVersion + "/[controller]")]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class SubCategoryController(ISubCategoryService service) : ControllerBase
    {
        private readonly ISubCategoryService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterQuery queryParams)
        {
            var requestUrl = Request.GetEncodedUrl();
            var data = await _service.GetSubCategories(queryParams, requestUrl);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var data = await _service.GetSubCategoryById(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUpdateSubCategoryViewModel body)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.CreateSubCategory(body, loggedUser!);

            return Created($"{Constants.ApiPrefixFirstVersion}/SubCategory", data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateUpdateSubCategoryViewModel body, long id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.UpdateSubCategory(id, body, loggedUser!);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            await _service.DeleteSubCategory(id, loggedUser!);

            return NoContent();
        }
    }
}
