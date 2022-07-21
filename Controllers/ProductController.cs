using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        public ProductController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _northwindContext.Products.ToList();
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
