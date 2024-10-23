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
        private readonly SalesService _salesService;

        public SalesController(DepartmentService departmentService, SellerService sellerService, SalesService salesService)
        {
            _departmentService = departmentService;
            _sellerService = sellerService;
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var nenhumDepartments = new Department { Id = 0, Name = " " };
            departments.Insert(0, nenhumDepartments);
            
            var sellers = await _sellerService.FindAllAsync();
            var nenhumSeller = new Seller { Id = 0, Nome = " " };
            sellers.Insert(0, nenhumSeller);
    
            var viewModel = new SalesViewModel { Departments = departments, Status = GetEnumSelectList<SaleStatus>(), Seles = new Seles(), Sellers = sellers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seles seles)
        {
            //if (!ModelState.IsValid)
            //{
            //    var departments = await _departmentService.FindAllAsync();
            //    var nenhumDepartments = new Department { Id = 0, Name = " " };
            //    departments.Insert(0, nenhumDepartments);

            //    var sellers = await _sellerService.FindAllAsync();
            //    var nenhumSeller = new Seller { Id = 0, Nome = " " };
            //    sellers.Insert(0, nenhumSeller);

            //    var viewModel = new SalesViewModel { Seles = seles, Departments = departments, Sellers = sellers, Status = GetEnumSelectList<SaleStatus>() };

            //    return View(viewModel);
            //}

            await _salesService.InsertAsync(seles);
            return RedirectToAction(nameof(Create));
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
