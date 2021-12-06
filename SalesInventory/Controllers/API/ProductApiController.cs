using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesInventory.Data.DbContext;
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
            DbHelper dbHelper = new DbHelper();
            var products = dbHelper.GetAllProducts();
            return Ok(products);
        }
    }
}
