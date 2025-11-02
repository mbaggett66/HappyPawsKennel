using HappyPawsKennel.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyPawsKennel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKennelService _kennelService;

        public HomeController(IKennelService kennelService)
        {
            _kennelService = kennelService;
        }

        public IActionResult Index()
        {
            int availableKennels = _kennelService.GetAvailableKennelCount();
            ViewBag.AvailableKennels = availableKennels;
            return View();
        }
    }
}
