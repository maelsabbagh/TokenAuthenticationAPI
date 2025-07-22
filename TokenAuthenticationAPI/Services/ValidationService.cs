using TokenAuthenticationAPI.DTO;
using TokenAuthenticationAPI.Models;

namespace TokenAuthenticationAPI.Services
{
    public class ValidationService : IValidationService
    {
        public User? ValidateUserCredentials(AuthenticationRequestBody authenticationRequestBody)
        {
            if (string.IsNullOrEmpty(authenticationRequestBody.UserName) || string.IsNullOrEmpty(authenticationRequestBody.Password)) return null;

            return new User()
            {
                UserId = 1,
                UserName = authenticationRequestBody.UserName ?? "",
                FirstName = "Mohamed",
                LastName = "Elsabbagh",
                City = "Cairo"
            };
        }
    }
}
