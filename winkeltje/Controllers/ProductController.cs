using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BL;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using winkeltje.Models;
using WinkelItem = winkeltje.Models.WinkelItem;

namespace winkeltje.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _manager = new ProductManager();

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
        public IActionResult Index(string modelIndex, string search, int id)
        {
            ProductIndexModel model;
            if (id != 0)
            {
                model = new ProductIndexModel
                {
                    Allergies = _manager.GetAllergies().ToList(), Products = new List<Product>(),
                    WinkelItems = new List<Models.WinkelItem>()
                };
                model.Products.Add(_manager.GetProduct(id));
                foreach (Allergie allergie in _manager.GetAllergies().ToList())
                {
                    model.WinkelItems.Add(new Models.WinkelItem
                    {
                        Id = allergie.AllergieId, Name = allergie.Naam
                    });
                }
            }
            else
            {
                if (search != null)
                {
                    IList<Product> products = new List<Product>();
                    IList<Allergie> allergies = _manager.GetAllergies().ToList();

                    foreach (Product product in _manager.GetProducts().ToList())
                    {
                        if (RemoveDiacritics(product.Naam.ToLower()).Contains(RemoveDiacritics(search.ToLower())))
                        {
                            products.Add(product);
                        }
                    }

                    model = new ProductIndexModel
                    {
                        Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                    };
                    foreach (Allergie allergie in allergies)
                    {
                        model.WinkelItems.Add(new Models.WinkelItem
                        {
                            Id = allergie.AllergieId, Name = allergie.Naam
                        });
                    }
                }
                else
                {
                    if (modelIndex != null)
                    {
                        model = new ProductIndexModel();
                        if (modelIndex.Length > 0)
                        {
                            IList<Product> products = new List<Product>();
                            IList<Allergie> allergies = _manager.GetAllergies().ToList();
                            IList<String> strings = modelIndex.Split("/").ToList();

                            foreach (string modelIndexWinkelItem in strings)
                            {
                                foreach (Product product in _manager.GetProducts().ToList())
                                {
                                    if (product.ProductAllergies.Find(x => x.Naam == modelIndexWinkelItem) != null)
                                    {
                                        products.Add(product);
                                    }
                                }

                            }

                            model = new ProductIndexModel
                            {
                                Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                            };
                            foreach (Allergie allergie in allergies)
                            {
                                model.WinkelItems.Add(new Models.WinkelItem
                                {
                                    Id = allergie.AllergieId, Name = allergie.Naam,
                                    Selected = modelIndex.Contains(allergie.Naam) ? true : false
                                });
                            }
                        }
                    }
                    else
                    {
                        IList<Product> products = _manager.GetProducts().ToList();
                        IList<Allergie> allergies = _manager.GetAllergies().ToList();
                        model = new ProductIndexModel
                        {
                            Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                        };
                        foreach (Allergie allergie in allergies)
                        {
                            model.WinkelItems.Add(new Models.WinkelItem
                            {
                                Id = allergie.AllergieId, Name = allergie.Naam
                            });
                        }
                    }
                }
            }

            return View(model);
        }
        public IActionResult IndexAdmin(string modelIndex, string search, int id)
        {
            ProductIndexModel model;
            if (id != 0)
            {
                model = new ProductIndexModel
                {
                    Allergies = _manager.GetAllergies().ToList(), Products = new List<Product>(),
                    WinkelItems = new List<Models.WinkelItem>()
                };
                model.Products.Add(_manager.GetProduct(id));
                foreach (Allergie allergie in _manager.GetAllergies().ToList())
                {
                    model.WinkelItems.Add(new Models.WinkelItem
                    {
                        Id = allergie.AllergieId, Name = allergie.Naam
                    });
                }
            }
            else
            {
                if (search != null)
                {
                    IList<Product> products = new List<Product>();
                    IList<Allergie> allergies = _manager.GetAllergies().ToList();

                    foreach (Product product in _manager.GetProducts().ToList())
                    {
                        if (RemoveDiacritics(product.Naam.ToLower()).Contains(RemoveDiacritics(search.ToLower())))
                        {
                            products.Add(product);
                        }
                    }

                    model = new ProductIndexModel
                    {
                        Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                    };
                    foreach (Allergie allergie in allergies)
                    {
                        model.WinkelItems.Add(new Models.WinkelItem
                        {
                            Id = allergie.AllergieId, Name = allergie.Naam
                        });
                    }
                }
                else
                {
                    if (modelIndex != null)
                    {
                        model = new ProductIndexModel();
                        if (modelIndex.Length > 0)
                        {
                            IList<Product> products = new List<Product>();
                            IList<Allergie> allergies = _manager.GetAllergies().ToList();
                            IList<String> strings = modelIndex.Split("/").ToList();

                            foreach (string modelIndexWinkelItem in strings)
                            {
                                foreach (Product product in _manager.GetProducts().ToList())
                                {
                                    if (product.ProductAllergies.Find(x => x.Naam == modelIndexWinkelItem) != null)
                                    {
                                        products.Add(product);
                                    }
                                }

                            }

                            model = new ProductIndexModel
                            {
                                Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                            };
                            foreach (Allergie allergie in allergies)
                            {
                                model.WinkelItems.Add(new Models.WinkelItem
                                {
                                    Id = allergie.AllergieId, Name = allergie.Naam,
                                    Selected = modelIndex.Contains(allergie.Naam) ? true : false
                                });
                            }
                        }
                    }
                    else
                    {
                        IList<Product> products = _manager.GetProducts().ToList();
                        IList<Allergie> allergies = _manager.GetAllergies().ToList();
                        model = new ProductIndexModel
                        {
                            Allergies = allergies, Products = products, WinkelItems = new List<Models.WinkelItem>()
                        };
                        foreach (Allergie allergie in allergies)
                        {
                            model.WinkelItems.Add(new Models.WinkelItem
                            {
                                Id = allergie.AllergieId, Name = allergie.Naam
                            });
                        }
                    }
                }
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult IndexNewAdmin(ProductIndexModel model)
        {
            string index = "";
            foreach (Models.WinkelItem modelWinkelItem in model.WinkelItems)
            {
                if (modelWinkelItem.Selected)
                {
                    index += modelWinkelItem.Name + "/";
                }
            }

            return RedirectToRoute(new 
            { 
                controller = "Product", 
                action = "IndexAdmin", 
                modelIndex = index, 
            });        
        }
        
        [HttpPost]
        public IActionResult IndexSearchAdmin(ProductIndexModel model)
        {
            return RedirectToRoute(new 
            { 
                controller = "Product", 
                action = "IndexAdmin", 
                modelIndex = "",
                search = model.SearchString, 
            });        
        }
        [HttpPost]
        public IActionResult IndexNew(ProductIndexModel model)
        {
            string index = "";
            foreach (Models.WinkelItem modelWinkelItem in model.WinkelItems)
            {
                if (modelWinkelItem.Selected)
                {
                    index += modelWinkelItem.Name + "/";
                }
            }

            return RedirectToRoute(new 
            { 
                controller = "Product", 
                action = "Index", 
                modelIndex = index, 
            });        
        }
        
        [HttpPost]
        public IActionResult IndexSearch(ProductIndexModel model)
        {
            return RedirectToRoute(new 
            { 
                controller = "Product", 
                action = "Index", 
                modelIndex = "",
                search = model.SearchString, 
            });        
        }
        
        public FileContentResult getImg(int id)
        {
            byte[] byteArray = _manager.GetProduct(id).ImageData;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }

        public IActionResult New()
        {
            WinkelViewModel model = new WinkelViewModel();
            model.Allergies = _manager.GetAllergies().ToList();
            model.Product = new Product();
            
            model.SelectedAllergies = new List<Models.WinkelItem>();
            foreach (Allergie allergie in model.Allergies)
            {
                model.SelectedAllergies.Add(new Models.WinkelItem()
                {
                    Id = allergie.AllergieId, Name = allergie.Naam
                });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(WinkelViewModel model)
        {
            using (var memoryStream = new MemoryStream())
            {
                await model.ImageFile.CopyToAsync(memoryStream);

                // Upload the file if less than 8 MB
                if (memoryStream.Length < 8388608)
                {
                    model.Product.ImageData = memoryStream.ToArray();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            List<ProductAllergie> productAllergies = new List<ProductAllergie>();
            if (ModelState.IsValid)
            {
                foreach (Models.WinkelItem item in model.SelectedAllergies)
                {
                    if (item.Selected)
                    {
                        productAllergies.Add(new ProductAllergie
                        {
                            Product = model.Product,
                            Naam = item.Name,
                            Allergie = _manager.GetAllergie(item.Id)
                        });
                    }

                    
                }
                
                
                
                model.Product.ProductAllergies = productAllergies;
                _manager.AddProduct(model.Product);
            }

            return RedirectToAction("Index", "Product");
        }
   
        [HttpGet("/Edit/{id:int?}")]
        public IActionResult Edit(int id = 1)
        {
            WinkelViewModel model = new WinkelViewModel();
            model.Allergies = _manager.GetAllergies().ToList();
            model.Product = _manager.GetProduct(id);
            
            model.SelectedAllergies = new List<Models.WinkelItem>();
            foreach (Allergie allergie in model.Allergies)
            {
                bool selected = false;
                foreach (ProductAllergie productAllergie in model.Product.ProductAllergies)
                {
                    if (productAllergie.Naam.Equals(allergie.Naam))
                    {
                        selected = true;
                    }
                }
                model.SelectedAllergies.Add(new Models.WinkelItem()
                {
                    Id = allergie.AllergieId, Name = allergie.Naam, Selected = selected
                        
                }); 
                
            }
            
        
            return View(model);
        }

        [HttpPost("/Edit/{id:int?}")]
        public async Task<ActionResult> Edit(int id, WinkelViewModel model)
        {
            if (model.ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(memoryStream);

                    // Upload the file if less than 8 MB
                    if (memoryStream.Length < 8388608)
                    {
                        model.Product.ImageData = memoryStream.ToArray();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }

            List<ProductAllergie> productAllergies = new List<ProductAllergie>();
            if (ModelState.IsValid)
            {
                foreach (Models.WinkelItem item in model.SelectedAllergies)
                {
                    if (item.Selected)
                    {
                        productAllergies.Add(new ProductAllergie
                        {
                            Product = model.Product,
                            Naam = item.Name,
                            Allergie = _manager.GetAllergie(item.Id)
                        });
                    }

                    
                }
                Product toChange = _manager.GetProduct(id);
                toChange.ProductAllergies = productAllergies;
                toChange.Naam = model.Product.Naam;
                toChange.Beschrijving = model.Product.Beschrijving;
                if (model.ImageFile != null)
                {
                    toChange.ImageData = model.Product.ImageData;
                }

                model.Product.ProductAllergies = productAllergies;
                _manager.ChangeProduct(toChange);
            }

            return RedirectToAction("Index", "Product");
        }
        
        [HttpGet("/Details/{id:int?}")]
        public IActionResult Details(int id = 1)
        {
            WinkelViewModel model = new WinkelViewModel();
            model.Allergies = _manager.GetAllergies().ToList();
            model.Product = _manager.GetProduct(id);
            
            model.SelectedAllergies = new List<Models.WinkelItem>();
            foreach (Allergie allergie in model.Allergies)
            {
                bool selected = false;
                foreach (ProductAllergie productAllergie in model.Product.ProductAllergies)
                {
                    if (productAllergie.Naam.Equals(allergie.Naam))
                    {
                        selected = true;
                    }
                }
                model.SelectedAllergies.Add(new Models.WinkelItem()
                {
                    Id = allergie.AllergieId, Name = allergie.Naam, Selected = selected
                        
                }); 
                
            }

            return RedirectToRoute(new 
            { 
                controller = "Product", 
                action = "Index", 
                id = id
            });             
            //return View(model);
        }
    }
}