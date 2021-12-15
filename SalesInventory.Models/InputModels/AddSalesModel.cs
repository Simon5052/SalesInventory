using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Models.InputModels
{
    public class AddSalesModel
    {
        public int QuantitySold { get; set; }
        public string SoldBy { get; set; }
        public int ProductId { get; set; }
        public double TotalAmount { get; set; }
    }
}
