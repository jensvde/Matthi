using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace winkeltje.Models
{
    public class ManagementModel
    {        public List<SelectListItem> ItemsProduct { get; set; }

        public List<SelectListItem> Items { get; set; }
        public int Id { get; set; }
    }
}