using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using ConnectSea.Api.Data;
using ConnectSea.Api.Models;

namespace ConnectSea.Api.Services {
    public interface IAuthService { Task<string?> AuthenticateAsync(string username, string password); }
    public class AuthService : IAuthService {
        private readonly PortoDbContext _db;
        private readonly IConfiguration _config;
        public AuthService(PortoDbContext db, IConfiguration config) { _db = db; _config = config; }
        public async Task<string?> AuthenticateAsync(string username, string password) {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"] ?? "change_this_demo_key_please");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username), new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
