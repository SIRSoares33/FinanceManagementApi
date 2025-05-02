using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Repository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Realiza o login do usuário.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserModel?> Login(LoginModel model);
        /// <summary>
        /// Realiza o cadastro do usuário.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RegisterAsync(UserModel model);
    }
}