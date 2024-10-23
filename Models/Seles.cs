using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seles
    {
        public int Id { get; set; }

        [Display(Name = "Seles Date")]
        [DataType(DataType.Date)]        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime DateSeles { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Seller Seller { get; set; }


        public int SellerId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public SaleStatus Status { get; set; }

        public Seles()
        {

        }

        public Seles(int id, DateTime dateSeles, Seller seller, Department department, double amount, SaleStatus status)
        {
            Id = id;
            DateSeles = dateSeles;
            Seller = seller;
            Department = department;
            Amount = amount;
            Status = status;
        }
      
    }
}
