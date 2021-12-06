using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInventory.Models.DbModels
{
    public class ProductCategoryModels
    {

        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Active { get; set; }
    }
}
