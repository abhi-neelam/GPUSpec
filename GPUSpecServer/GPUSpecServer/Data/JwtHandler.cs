using GPUSpecServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GPUSpecServer.Data
{
    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        public JwtHandler(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager
            )
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<SecurityTokenDescriptor> GetTokenDescriptorAsync(ApplicationUser user)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                Claims = await GetClaimsAsync(user),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiryInMinutes"])),
                SigningCredentials = GetSigningCredentials()
            };

            return descriptor;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<Dictionary<string, object>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = new Dictionary<string, object>
            {
                { JwtRegisteredClaimNames.Sub, user.Id },
                { JwtRegisteredClaimNames.Name, user.UserName! },
                { JwtRegisteredClaimNames.Email, user.Email! },
            };

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Any())
            {
                claims.Add(ClaimTypes.Role, roles);
            }

            return claims;
        }
    }
}