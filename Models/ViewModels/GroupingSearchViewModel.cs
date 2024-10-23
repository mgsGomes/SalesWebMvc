using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class GroupingSearchViewModel
    {
        public IEnumerable<IGrouping<Department, SalesRecord>> GroupedSalesRecords { get; set; }
        public List<Department> Departments { get; set; }
        public int SelectedDepartmentId { get; set; }
    }
}
