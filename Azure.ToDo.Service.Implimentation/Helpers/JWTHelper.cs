using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Azure.ToDo.Service.Implimentation.Helpers
{
    public static class JWTHelper
    {
        public static string GenerateEncodedToken(IConfiguration configuration, Guid userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId" , userId.ToString()),
                    new Claim("userName" , userName),
                    new Claim("iss",configuration["Jwt:Issuer"] ),
                    new Claim( "aud" , configuration["Jwt:Audience"] )
                    // Add additional claims as desired
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
