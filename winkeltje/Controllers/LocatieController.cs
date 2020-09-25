using Microsoft.AspNetCore.Mvc;

namespace winkeltje.Controllers
{
    public class LocatieController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}