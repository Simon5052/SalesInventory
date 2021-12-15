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
        private readonly DbHelper _dbHelper;
        public ProductController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }
        
        
        public IActionResult All()
        {
            ViewBag.Products = _dbHelper.GetAllProducts();
            return View();
        }

        public IActionResult AllProductCategory()
        {
            ViewBag.ProductCategory = _dbHelper.GetAllProductCategories();
            return View();
        }

        public IActionResult AllSales()
        {
            ViewBag.ProductSales = _dbHelper.GetAllSales();
            return View();
        }
        





    }
}
