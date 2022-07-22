using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMVC.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        public ProductController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("List")]
        public Task<JsonResult> List()
        {
            return Json(_northwindContext.Products.ToList());
        }

        [HttpDelete("bom/{id}")]
        public  Task<JsonResult> bom(string id)
        {
            var product = _northwindContext.Products.Find(id);
            if (product.UnitsInStock>0)
            {
                int UnitsInStock = Int32.Parse(product.UnitsInStock);
                UnitsInStock -= 1;
                product.UnitsInStock = UnitsInStock.ToString();
                _northwindContext.Update(product);
                _northwindContext.SaveChanges();
                return Json("成功!");
            }
            else
            {
                return Json("需要採購!");
            }
                        
            
        }

    }
}
