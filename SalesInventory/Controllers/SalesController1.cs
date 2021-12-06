using Microsoft.AspNetCore.Mvc;
using SalesInventory.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers
{
    public class SalesController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PerProductId(int productId)
        {
            DbHelper dbHelper = new DbHelper();
            ViewBag.ProductSalesById = dbHelper.GetAllSalesById(productId);
            return View();
        }
    }
}
