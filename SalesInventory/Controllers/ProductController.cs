using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesInventory.Data.DbContext;
using SalesInventory.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers
{
    public class ProductController : Controller
    {
        
        
        public IActionResult All()
        {
            DbHelper dbHelper = new DbHelper();
            ViewBag.Products = dbHelper.GetAllProducts();
            return View();
        }

        public IActionResult AllProductCategory()
        {
            DbHelper dbHelper = new DbHelper();
            ViewBag.ProductCategory = dbHelper.GetAllProductCategories();
            return View();
        }

        public IActionResult AllSales()
        {
            DbHelper dbHelper = new DbHelper();
            ViewBag.ProductSales = dbHelper.GetAllSales();
            return View();
        }
        





    }
}
