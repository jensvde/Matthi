using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using BL;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using winkeltje.Models;

namespace winkeltje.Controllers
{
    public class DatabaseController : Controller
    {
        private ProductManager _manager = new ProductManager();

        // GET
        public IActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> itemsProduct = new List<SelectListItem>();

            ManagementModel model = new ManagementModel();
            foreach (Allergie allergie in _manager.GetAllergies())
            {
                items.Add(new SelectListItem
                {
                    Value = allergie.AllergieId+"", Text = allergie.Naam
                });
            }

            foreach (Product product in _manager.GetProducts())
            {
                itemsProduct.Add(new SelectListItem
                {
                    Value = product.ProductId+"", Text = product.Naam
                });
            }

            model.Items = items;
            model.ItemsProduct = itemsProduct;
            return View(model);
        }

        [HttpGet]
        public ActionResult Export()
        {
            var json = JsonSerializer.Serialize(_manager.GetProducts().ToList());

            using (var ms = new MemoryStream()) {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true))) {
                    sw.Write(json);
                    }// The stream gets flushed here.
                    return File(ms.ToArray(), "json", $"export_{DateTime.UtcNow.Ticks}.json");
                }
            }
        }
    }
