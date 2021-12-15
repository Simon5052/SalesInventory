using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesInventory.Data.DbContext;
using SalesInventory.Models;
using SalesInventory.Models.DbModels;
using SalesInventory.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers.API
{
   

    [Route("api/[controller]")]
    [ApiController]

    public class ProductApiController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        public ProductApiController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }
        [HttpGet]
        [Route("GenerateRandom")]

        public IActionResult GenerateRandom()
        {
            var random = new Random();
            int randomNumber = random.Next();
            return Ok(randomNumber);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _dbHelper.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int productId)
        {
            var products = _dbHelper.GetProductById(productId);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllSalesById")]
        public IActionResult GetAllSalesByProductId(int productId)
        {
            var products = _dbHelper.GetAllSalesById(productId);
            return Ok(products);
        }

        [HttpPost]
        [Route("InsertSales")]
        public IActionResult RecordSales(AddSalesModel addSales)
        {
            
            var products = _dbHelper.GetAllProducts();
            var product = products.FirstOrDefault(p => p.ProductId == addSales.ProductId);
            addSales.TotalAmount = product.Cost * addSales.QuantitySold;
            var dbResponse = _dbHelper.InsertSale(addSales.ProductId, addSales.QuantitySold, addSales.TotalAmount, addSales.SoldBy);
            if(dbResponse == "success")
            {
                return Ok("succesful");

            }
            else
            {
                return BadRequest(dbResponse);
            }

            
        }



    }
}
