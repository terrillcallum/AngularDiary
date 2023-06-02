using Microsoft.AspNetCore.Identity;

namespace Project1.Models
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}
