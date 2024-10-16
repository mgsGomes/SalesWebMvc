using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SalesViewModel
    {
        public Seles Seles { get; set; }
        public ICollection<Department> Departments { get; set; }      
        public IEnumerable<SelectListItem> Status { get; set; }
        public ICollection<Seller> Sellers { get; set; }
    }
}
