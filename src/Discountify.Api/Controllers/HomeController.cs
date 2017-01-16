namespace Discountify.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

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
            return Ok(this.cardService.List());
        }
    }
}
