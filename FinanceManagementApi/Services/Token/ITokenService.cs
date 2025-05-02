using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(UserModel user);
    }
}