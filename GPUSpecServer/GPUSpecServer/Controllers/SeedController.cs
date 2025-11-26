using GPUSpecServer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "administrator")]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public SeedController(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _env = env;
            _configuration = configuration;
        }

        [HttpPost("UsersRoles")]
        public async Task<ActionResult> PostUsersRoles()
        {
            string role_RegisteredUser = "registeredUser";
            string role_Administrator = "administrator";

            if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }

            if (await _roleManager.FindByNameAsync(role_Administrator) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
                
            var addedUserList = new List<ApplicationUser>();
            var email_Admin = "admin@email.com";
            var username_Admin = "admin";

            if (await _userManager.FindByEmailAsync(email_Admin) == null)
            {
                var user_Admin = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = username_Admin,
                    Email = email_Admin,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                await _userManager.CreateAsync(user_Admin, _configuration["DefaultPasswords:admin"]!);
                await _userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
                await _userManager.AddToRoleAsync(user_Admin, role_Administrator);
                addedUserList.Add(user_Admin);
            }

            var email_User = "user@email.com";
            var username_User = "user";

            if (await _userManager.FindByEmailAsync(email_User) == null)
            {
                var user_User = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = username_User,
                    Email = email_User,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                await _userManager.CreateAsync(user_User, _configuration["DefaultPasswords:user"]!);
                await _userManager.AddToRoleAsync(user_User, role_RegisteredUser);

                addedUserList.Add(user_User);
            }

            if (addedUserList.Count > 0)
            {
                await _context.SaveChangesAsync();
            }

            return new JsonResult(new
            {
                Count = addedUserList.Count,
                Users = addedUserList
            });
        }
    }
}
