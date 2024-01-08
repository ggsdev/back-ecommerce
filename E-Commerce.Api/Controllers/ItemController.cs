using E_Commerce.Api._Base.Filters;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route(Constants.API_PREFIX_FIRST_VERSION + "/[controller]")]
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class ItemController(IItemService service) : ControllerBase
    {
        private readonly IItemService _service = service;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] FilterQuery queryParams, CancellationToken ct)
        {
            var requestUrl = Request.GetEncodedUrl();

            var data = await _service.GetItems(queryParams, requestUrl, ct);

            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetItemById(id);

            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Post([FromBody] CreateUpdateItemViewModel body)
        {
            var data = await _service.CreateItem(body);

            return Created($"{Constants.API_PREFIX_FIRST_VERSION}/Item", data);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Put(int id, [FromBody] CreateUpdateItemViewModel body)
        {
            var data = await _service.UpdateItem(body, id);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.ADMIN)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItem(id);

            return NoContent();
        }
    }
}