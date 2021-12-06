using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInventory.Models.DbModels
{
    public class ProductModels
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }

        public int StockAvailable { get; set; }
        public double Cost { get; set; }

    }
}
