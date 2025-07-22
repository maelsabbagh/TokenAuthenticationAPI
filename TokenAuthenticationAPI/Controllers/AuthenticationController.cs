using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TokenAuthenticationAPI.DTO;
using TokenAuthenticationAPI.Services;

namespace TokenAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IValidationService _validationService;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IValidationService validationService, IConfiguration configuration,ITokenService tokenService)
        {
            _validationService = validationService;
            _configuration = configuration;
            _tokenService = tokenService;
        }
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            try
            {
                // validate 
                var user = _validationService.ValidateUserCredentials(authenticationRequestBody);
                if (user == null)
                {
                    return Unauthorized();
                }

                var token = _tokenService.GenerateToken(user);

                return Ok(token);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
