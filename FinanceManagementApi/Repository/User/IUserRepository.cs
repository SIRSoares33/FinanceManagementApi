using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Repository.User
{
    public interface IUserRepository
    {
        Task<UserModel?> Login(LoginModel model);
    }
}