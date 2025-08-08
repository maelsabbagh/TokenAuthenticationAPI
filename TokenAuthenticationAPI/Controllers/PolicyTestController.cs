using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy="MustBeFromCairo")]
    public class PolicyTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult cairoCitizens()
        {
            return Ok("Hello, you are from Cairo");
        }
    }
}
