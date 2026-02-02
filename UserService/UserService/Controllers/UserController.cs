using Microsoft.AspNetCore.Mvc;
using UserService.Business.Interfaces;
using UserService.CQRS.Commands;
using UserService.Model.Models;

namespace UserService.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadService _read;
        private readonly IUserWriteService _write;

        public UsersController(IUserReadService read, IUserWriteService write)
        {
            _read = read;
            _write = write;
        }

        // READ
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _read.GetAll());
        }
            

        [HttpGet("UserEmailOrId")]
        public async Task<IActionResult> UserByEmailOrId(Guid id, string email)
        {
            var user = await _read.GetById(id, email);
            return user == null ? NotFound() : Ok(user);
        }

        // WRITE
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand cmd)
        {
            var response = await _write.Create(cmd);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserCommand cmd)
        {
            await _write.Update(cmd with { Id = id });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _write.Delete(new DeleteUserCommand(id));
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            var result = await _read.LoginAsync(request);
            if (result is null)
                return NoContent();
            return Ok(result);
        }
    }

}
