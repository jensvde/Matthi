using System.Linq;
using BL;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace winkeltje.Controllers
{
     
    public class AllergieController : Controller
    {
        private ProductManager _manager = new ProductManager();

        // GET
        public IActionResult Index()
        {
            return View(_manager.GetAllergies().ToList());
        }
        
        public IActionResult New()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(_manager.GetAllergie(id));
        }
        [HttpPost]
        public IActionResult New(Allergie allergie)
        {
            if (ModelState.IsValid)
            {
                _manager.AddAllergie(allergie);
                return RedirectToAction("Index", "Allergie");
            }

            return View();
        }
      
    }
}