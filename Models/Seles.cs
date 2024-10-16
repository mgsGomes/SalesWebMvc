using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seles
    {
        public int Id { get; set; }
        public DateTime DateSeles { get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public double Amount { get; set; }
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
