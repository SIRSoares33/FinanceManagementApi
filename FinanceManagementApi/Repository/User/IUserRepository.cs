using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Repository.User
{
    /// <summary>
    /// Interface responsável pela camada de gerenciamento de dados.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Pega um usuário pelo email no banco de dados.
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
        /// Deleta um usuário.
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
        /// <summary>
        /// Pega um usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserModel?> GetUserById(int id);
    }
}