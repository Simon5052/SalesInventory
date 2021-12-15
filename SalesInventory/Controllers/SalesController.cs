using Microsoft.AspNetCore.Mvc;
using SalesInventory.Data.DbContext;
using SalesInventory.Models;
using SalesInventory.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers
{
    public class SalesController : Controller
    {
        private readonly DbHelper _dbHelper;

        public SalesController(DbHelper dbHelper )
        {
            _dbHelper = dbHelper;

        }
        public IActionResult RecordSales(int productId)
        {
            ViewBag.ProductSales = _dbHelper.GetAllSalesById(productId);
            ViewBag.ProductId = productId;
            ViewBag.Products = _dbHelper.GetAllProducts();
            ViewBag.GetProductById = _dbHelper.GetProductById(productId);
            return View();
        }

        [HttpPost]
        public IActionResult RecordSales(AddSalesModel addSales)
        {
            var products = _dbHelper.GetAllProducts();
            var product = products.FirstOrDefault(p => p.ProductId == addSales.ProductId);
            var totalAmount = product.Cost * addSales.QuantitySold;
            var insertSale = _dbHelper.InsertSale(addSales.ProductId, addSales.QuantitySold, totalAmount, addSales.SoldBy);
            return RedirectToAction("RecordSales", "Sales", new { productId = product.ProductId });
        }




    }
}
