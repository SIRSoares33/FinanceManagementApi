using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Repository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Realiza o login do usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserModel?> GetUserByEmail(string email);
        /// <summary>
        /// Realiza o cadastro do usuário.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddUserAsync(UserModel model);
        /// <summary>
        /// Deleta um usuário com base no id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteUserAsync(UserModel userToDelete);
        /// <summary>
        /// Verifica se um email já existe no banco de dados.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> VerifyEmailExistsInDb(string email);
        Task<UserModel?> GetUserById(int id);
    }
}