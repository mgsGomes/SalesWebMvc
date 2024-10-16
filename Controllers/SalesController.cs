using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly SellerService _sellerService;

        public SalesController(DepartmentService departmentService, SellerService sellerService)
        {
            _departmentService = departmentService;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var sellers = await _sellerService.FindAllAsync();
    
            var viewModel = new SalesViewModel { Departments = departments, Status = GetEnumSelectList<SaleStatus>(), Seles = new Seles(), Sellers = sellers };
            return View(viewModel);
        }

        public static IEnumerable<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => new SelectListItem
            {
                Value = ((int)(object)e).ToString(),
                Text = e.ToString()
            });
        }

    }
}
