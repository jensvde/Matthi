using System;
using System.Collections.Generic;
using BL;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace winkeltje.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _manager = new ProductManager();
        public IActionResult Index()
        {
            IEnumerable<Product> products = _manager.GetProducts();
            return View(products);
        }

        public FileContentResult getImg(int id)
        {
            byte[] byteArray = _manager.GetProduct(id).ImageData;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }
    }
}