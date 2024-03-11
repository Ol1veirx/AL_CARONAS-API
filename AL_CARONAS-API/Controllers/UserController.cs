using AL_CARONAS.Application.InputModels;
using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AL_CARONAS_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();

            var usersDtos = users.Select(u => new UserDto
            {
                Email = u.Email,
                Name = u.Name,
                Phone = u.Phone,
            });

            return Ok(usersDtos);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetById(int userId)
        {
            var user = await _service.GetUserByIdAsync(userId);

            if (user == null) return NotFound();

            var userDto = new UserDto
            {
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var newUser = await _service.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { userId = newUser.UserId }, newUser);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var delete = await _service.DeleteUserAsync(userId);

            if (!delete) return BadRequest();

            return NoContent();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser(LoginModel loginModel)
        {
            var authenticated = await _service.AuthenticateUserAsync(loginModel.Email, loginModel.Password);
            if (!authenticated) return Unauthorized();

            return Ok();
        }
    }
}
