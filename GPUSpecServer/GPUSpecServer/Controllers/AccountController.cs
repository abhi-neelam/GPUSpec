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

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(ApiSignupRequestDTO signupRequest)
        {
            var user = await _userManager.FindByEmailAsync(signupRequest.Email);
            if (user != null)
            {
                return Conflict(new ApiSignupResultDTO()
                {
                    Success = false,
                    Message = "The email address already exists"
                });
            }

            var user_User = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signupRequest.Email,
                Email = signupRequest.Email,
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            var createResult = await _userManager.CreateAsync(user_User, signupRequest.Password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));

                return BadRequest(new ApiSignupResultDTO
                {
                    Success = false,
                    Message = $"Weak password {errors}"
                });
            }

            string role_RegisteredUser = "registeredUser";
            await _userManager.AddToRoleAsync(user_User, role_RegisteredUser);

            var secToken = await _jwtHandler.GetTokenDescriptorAsync(user_User);
            var handler = new JsonWebTokenHandler();
            handler.SetDefaultTimesOnTokenCreation = false;

            var jwt = handler.CreateToken(secToken);

            return Created(string.Empty, new ApiLoginResultDTO()
            {
                Success = true,
                Message = "Signup successful",
                Token = jwt
            });
        }
    }
}