using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("getproducts")]
        public IActionResult ProductList()
        {
            var products = _configuration.GetSection("ProductList")?.Value;

            if (string.IsNullOrWhiteSpace(products))
                return NotFound();
            
            var productList = products.Split(";",System.StringSplitOptions.RemoveEmptyEntries).ToList();
            return Ok(productList);
        }
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("Product API Run!");
        }
    }
}
