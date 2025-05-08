using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.JwtParser
{
    public class JwtParser(JwtSecurityTokenHandler handler) : IJwtParser
    {
        public LoggedUserModel GetLoggedUserModel(string token)
        {
            var claims = handler.ReadJwtToken(token).Claims;

            return new()
            {
                Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty),
                Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? string.Empty
            };
        }
    }
}