using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Wep_1.Application.UseCases.Users.Commands;
using Wep_1.Application.UseCases.Users.Queries;
using Wep_1.Domain.Entities;
using Wep_Api_1.Dtos;

namespace Wep_Api_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UserDto dto)
        {
            try
            {
                var command = new CreateUserCommand()
                {
                    Name = dto.Name
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetAllUsersCommand());

                if (res == null)
                    throw new Exception("Users Not Found!!");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUserAsync([FromForm] int id)
        {
            try
            {
                var value = _memoryCache.Get("User_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "User_key",
                        value: await _mediator.Send(new GetByIdUserCommand()));
                }
                return Ok(_memoryCache.Get("Users_key") as User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync([FromForm] int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteUserCommand() { Id = id });
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync([FromForm] int id, [FromBody] UserDto dto)
        {
            try
            {
                var command = new UpdateUserCommand()
                {
                    Id = id,
                    Name = dto.Name,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
