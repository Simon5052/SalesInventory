using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SalesInventory.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesInventory.Controllers
{
    public class ProductCategoryController : Controller
    {
        public readonly DbHelper _dbHelper;
        public ProductCategoryController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }

        public IActionResult All()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult ProductCategory_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data =  _dbHelper.GetAllProductCategories();
           
            return Json(data.ToDataSourceResult(request));
        }
    }
}
