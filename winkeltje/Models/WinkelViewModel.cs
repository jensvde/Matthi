using System.Collections.Generic;
using System.Net.Mime;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace winkeltje.Models
{
    public class WinkelViewModel
    {
        public IList<Allergie> Allergies { get; set; } 
        public Product Product { get; set; } 

        public IList<WinkelItem> SelectedAllergies { get; set; } 
        public IFormFile ImageFile { get; set; }

        
    }

    public class WinkelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}