namespace Discountify.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Linq;

    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ICardService cardService;

        public HomeController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        public IActionResult Index()
        {
            var claims = User.Claims.Select(claim => new { claim.Type, claim.Value });

            return Ok(claims);
        }
        
        [Authorize]
        [Route("test")]
        public IActionResult Test()
        {
            var claims = User.Claims.Select(claim => new { claim.Type, claim.Value });

            return Ok(claims);
        }
    }
}
