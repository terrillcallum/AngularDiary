using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService; // You will have to implement this

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return Ok(new { Token = _tokenService.CreateToken(user) });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var user1 = new IdentityUser { UserName = "example@example.com", Email = "example@example.com" };
            var result1 = await _userManager.CreateAsync(user1, "qQ!1234");
            var user2 = await _userManager.FindByEmailAsync("example@example.com");
            //var reguser = new IdentityUser { UserName = model.Email, Email = model.Email };
            //await _userManager.CreateAsync(reguser, model.Password);
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                return Ok(new { Token = _tokenService.CreateToken(user) });
            }
            return Unauthorized();
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
