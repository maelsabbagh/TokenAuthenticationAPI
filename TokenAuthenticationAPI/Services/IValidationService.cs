using TokenAuthenticationAPI.DTO;
using TokenAuthenticationAPI.Models;

namespace TokenAuthenticationAPI.Services
{
    public interface IValidationService
    {
        public User? ValidateUserCredentials(AuthenticationRequestBody authenticationRequestBody);
    }
}
