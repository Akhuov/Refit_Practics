using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Wep_1.Application.UseCases.Products.Commands;
using Wep_1.Application.UseCases.Products.Queries;
using Wep_1.Domain.Entities;
using Wep_Api_1.Dtos;

namespace Wep_Api_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateProductAsync(ProductDto dto)
        {
            try
            {
                var command = new CreateProductCommand()
                {
                    Name = dto.Name,
                    UserId = dto.UserId
                };

                var res = await _mediator.Send(command);
                _memoryCache.Remove("Products_key");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var value = _memoryCache.Get("Products_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Products_key",
                        value: await _mediator.Send(new GetAllProductsCommand()));
                }
                return Ok(_memoryCache.Get("Products_key") as List<Product>);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdProductAsync([FromForm] int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdProductCommand() { Id = id });
                if(res == null)
                {
                    throw new Exception();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductAsync([FromForm] int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteProductCommand() { Id = id });

                if (res == null)
                    throw new Exception("Product Not Found!!");

                _memoryCache.Remove("Products_key");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateProductAsync([FromForm] int id)
        {
            try
            {
                var res = await _mediator.Send(UpdateProductAsync(id));

                if (res == null)
                    throw new Exception("Product Not Found!!");
                _memoryCache.Remove("Product_key");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
