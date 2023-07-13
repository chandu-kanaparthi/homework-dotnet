using Microsoft.AspNetCore.Mvc;

namespace SwEngHomework.WebApp.Controllers
{
    public class OtherController : Controller
    {
        private readonly ILogger<OtherController> _logger;

        public OtherController(ILogger<OtherController> logger)
        {
            _logger = logger;
        }

        public IActionResult EvenMinute()
        {
            return View();
        }
    }
}
