using Microsoft.AspNetCore.Mvc;

namespace winkeltje.Controllers
{
    public class OverOnsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}