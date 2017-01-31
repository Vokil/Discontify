namespace Discountify.Api.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Threading.Tasks;

    public class AppUser
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsMale { get; set; }
    }

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login(User model)
        {
            //TODO: Improve logic
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }

            signInManager.PasswordSignInAsync(model.UserName, model.Email, true, false);

            return Ok();
        }

        public async Task<IActionResult> Logout()
        {
            //TODO: Improve logic
            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
            }

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]AppUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    IsMale = model.IsMale
                };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("Registrated");
                }

                return BadRequest(result.Errors);
            }

            return BadRequest("Registration values are wrong!");
        }
    }
}
