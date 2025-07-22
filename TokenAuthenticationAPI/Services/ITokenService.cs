using TokenAuthenticationAPI.Models;

namespace TokenAuthenticationAPI.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
