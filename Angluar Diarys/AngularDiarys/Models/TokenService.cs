using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project1.Models
{
    public class TokenService : ITokenService
    {
        public string CreateToken(IdentityUser user)
        {
            // Here is where you generate a JWT (or other token) and return it as a string.
            // This is just a simple example and a real implementation would require more complex logic.

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var secretBytes = Encoding.UTF8.GetBytes("$£!GVFDWVB213145152e12v134fg21f4dWFD£d2x24cd324c32"); // You should use a secret from your configuration here
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials
            );

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }
    }

}
