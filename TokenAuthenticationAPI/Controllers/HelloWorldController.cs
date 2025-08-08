using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {

        [HttpGet]
        public IActionResult WelcomeMessage([FromQuery] string name)
        {
            string message = $"Hello {name}";
            return Ok(new HelloDTO 
            {
                message=message
            });
        }
    }

    public class HelloDTO
    {
        public string message { get; set; }
    }
}
