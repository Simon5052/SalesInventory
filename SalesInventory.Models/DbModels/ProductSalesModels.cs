using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInventory.Models.DbModels
{
    public class ProductSalesModels
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SoldBy { get; set; }
        public int StockAvailable { get; set; }
        public string ProductName { get; set; }






    }
}
