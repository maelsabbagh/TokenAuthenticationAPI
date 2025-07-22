using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TokenAuthenticationAPI.Models;

namespace TokenAuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;   
        }
        public string GenerateToken(User user)
        {

            // token consists of 3 parts:
            // header
            // payload (claims)
            //signature ( needs secret key,security algorithm)
            var securityKey = new SymmetricSecurityKey(
                            Convert.FromBase64String(_configuration["Authentication:SecretForKey"])
                            );

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();

            claimsForToken.Add(new Claim("Sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city", user.City));

            var jwtsSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtsSecurityToken);

            return token;
        }
    }
}
