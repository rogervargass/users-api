using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.DTOs;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto dto)
        {
            await _userService.Register(dto);
            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var token = await _userService.Login(dto);
            return Ok(token);
        }
    }
}