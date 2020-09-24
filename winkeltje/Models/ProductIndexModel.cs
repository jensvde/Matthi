using System.Collections.Generic;
using Domain;

namespace winkeltje.Models
{
    public class ProductIndexModel
    {
        public IList<Allergie> Allergies { get; set; }
        public IList<Product> Products { get; set; }
        public string SearchString { get; set; }
        public IList<WinkelItem> WinkelItems { get; set; }
    }
}

public class WinkelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
