using GPUSpecServer.Data;
using GPUSpecServer.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            JwtHandler jwtHandler)
        {
            _context = context;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(ApiLoginRequestDTO loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return Unauthorized(new ApiLoginResultDTO()
                {
                    Success = false,
                    Message = "Invalid Email or Password"
                });
            }

            var secToken = await _jwtHandler.GetTokenDescriptorAsync(user);
            var handler = new JsonWebTokenHandler();
            handler.SetDefaultTimesOnTokenCreation = false;

            var jwt = handler.CreateToken(secToken);

            return Ok(new ApiLoginResultDTO()
            {
                Success = true,
                Message = "Login successful",
                Token = jwt
            });
        }
    }
}
