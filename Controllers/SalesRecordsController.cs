using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesWebMvcContext _context;
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesWebMvcContext context, SalesRecordService salesRecordService)
        {
            _context = context;
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            var departments = _context.Department.OrderBy(x => x.Name).ToList();
            var allDepartments = new Department { Id = 0, Name = "(Todos)" };

            departments.Insert(0, allDepartments);

            var viewModel = new SalesFormViewModel { Departments = departments };

            return View(viewModel);
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate, int departmentId)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var departments = await _context.Department.OrderBy(x => x.Name).ToListAsync();
            var allDepartments = new Department { Id = 0, Name = "(Todos)" };
            departments.Insert(0, allDepartments);

            var groupedSalesRecords = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate, departmentId);

            var viewModel = new GroupingSearchViewModel { Departments = departments, GroupedSalesRecords = groupedSalesRecords, SelectedDepartmentId = departmentId };

            return View(viewModel);
        }
    }
}
