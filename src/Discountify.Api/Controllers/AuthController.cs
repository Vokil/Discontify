namespace Discountify.Api.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> signInManager;

        public AuthController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
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
    }
}
