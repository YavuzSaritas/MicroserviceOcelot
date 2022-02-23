using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GatewayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatewayController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("Gateway API Run!");
        }
    }
}
