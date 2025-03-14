using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OccazNet.Core.Models.Users;
using OccazNet.Core.Services.Interfaces;

namespace OccazNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
                return Unauthorized("Email ou mot de passe incorrect.");

            return Ok(new { Token = token });
        }
    }
}
