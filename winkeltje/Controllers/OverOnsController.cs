using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace winkeltje.Controllers
{
    public class OverOnsController : Controller
    {
        // GET
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}