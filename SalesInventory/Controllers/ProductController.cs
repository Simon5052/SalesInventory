using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesInventory.Data.DbContext;
using SalesInventory.Models;
using SalesInventory.Models.DbModels;
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
            //ViewBag.Products = _dbHelper.GetAllProducts();
            return View();
        }

        public IActionResult AllProductCategory()
        {
            ViewBag.ProductCategory = _dbHelper.GetAllProductCategories();
            return View();
        }

        [HttpGet]
        public IActionResult AllCategory()
        {
            var productCategories = _dbHelper.GetAllProductCategories();
            return Ok(productCategories);
        }

        public IActionResult AllSales()
        {
            ViewBag.ProductSales = _dbHelper.GetAllSales();
            return View();
        }

        [HttpPost]
        public IActionResult Product_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetAllProducts();

            return Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public IActionResult Product_Add([DataSourceRequest] DataSourceRequest request, ProductModels model)
        {
            if (string.IsNullOrWhiteSpace(model.ProductName) || model.ProductName.Length < 2)
                return BadRequest("CPG Vendor Name should have a minimum of 2 characters");




            var dbResponse = _dbHelper.InsertProduct(model.ProductName, model.ProductCategoryId, model.StockAvailable, model.Cost);



            if (dbResponse == "Successful")
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            else 
                return BadRequest("Oops! An error occurred while adding CPG Vendor. Please retry.");



        }

        [HttpPost]
        public IActionResult Product_Delete([DataSourceRequest] DataSourceRequest request, ProductModels model)
        {
            if (string.IsNullOrWhiteSpace(model.ProductName) || model.ProductName.Length < 2)
                return BadRequest("CPG Vendor Name should have a minimum of 2 characters");




            var dbResponse = _dbHelper.DeleteProduct(model.ProductId);



            if (dbResponse == "Deleted")
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            else
                return BadRequest("Oops! An error occurred while adding CPG Vendor. Please retry.");



        }


        [HttpPost]
        public IActionResult Product_Update([DataSourceRequest] DataSourceRequest request, ProductModels model)
        {
            if (string.IsNullOrWhiteSpace(model.ProductName) || model.ProductName.Length < 2)
                return BadRequest("The Product Wasn Not Updated");




            var dbResponse = _dbHelper.UpdateProduct(model.ProductId, model.ProductName, model.ProductCategoryId, model.Cost, model.StockAvailable);



            if (dbResponse == "Updated")
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            else
                return BadRequest("Oops! An error occurred while Updating Product. Please retry.");



        }





    }
}
