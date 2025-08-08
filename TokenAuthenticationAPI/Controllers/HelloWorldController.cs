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

        [HttpGet("claims")]
        public IActionResult claims()
        {
            // get from claims set in tokenservice
            var city = User.Claims.FirstOrDefault(c => c.Type == "city");
            return Ok(city.ToString());
        }
        [HttpGet("test-type")]
        public IActionResult testType()
        {
            var testType = User.Claims.FirstOrDefault(c => c.Type == "testType").ToString();
            return Ok(testType); // return Mohamed is adding a new test Type
        }
    }

    public class HelloDTO
    {
        public string message { get; set; }
    }
}
