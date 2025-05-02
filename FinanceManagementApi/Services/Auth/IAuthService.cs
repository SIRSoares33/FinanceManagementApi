using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Services.Auth
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginModel model);
        Task RegisterAsync(UserModel model);
        Task DeleteAsync(int id);
    }
}