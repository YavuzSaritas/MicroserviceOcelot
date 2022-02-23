using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CostumerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("getcustomers")]
        public async Task<IActionResult> CustomerList()
        {
            var customers = _configuration.GetSection("CustomerList")?.Value;

            if (string.IsNullOrWhiteSpace(customers))
                return NotFound();

            var customerList = customers.Split(";", System.StringSplitOptions.RemoveEmptyEntries).ToList();
            return Ok(customerList);
        }

        [HttpGet("status")]
        public async Task<IActionResult> Status()
        {
            return Ok("Product API Run!");
        }
    }
}
