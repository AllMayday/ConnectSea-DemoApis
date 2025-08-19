using Microsoft.AspNetCore.Mvc;
using ConnectSea.Api.Services;

namespace ConnectSea.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) { _auth = auth; }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto) {
            var token = await _auth.AuthenticateAsync(dto.Username, dto.Password);
            if (token == null) return Unauthorized(new { error = "Invalid credentials" });
            return Ok(new { token });
        }
    }

    public record LoginDto(string Username, string Password);
}
