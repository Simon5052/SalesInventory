using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
