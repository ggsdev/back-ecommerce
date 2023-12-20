using E_Commerce.Api._Base.Filters;
using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
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
        public async Task<IActionResult> Get(long id)
        {
            var data = await _service.GetItemById(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUpdateItemViewModel body, CancellationToken ct)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.CreateItem(body, loggedUser!);

            return Created("v1/api/item", data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CreateUpdateItemViewModel body, CancellationToken ct)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            var data = await _service.UpdateItem(body, id, loggedUser!);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken ct)
        {
            var loggedUser = HttpContext.Items["User"] as User;

            await _service.DeleteItem(id, loggedUser!);

            return NoContent();
        }
    }
}