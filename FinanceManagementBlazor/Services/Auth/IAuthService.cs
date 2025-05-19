using Finance.Dtos;
using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.Auth
{
    /// <summary>
    /// Define os métodos para gerenciar a autenticação de usuários.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="dto">O modelo contendo as informações do usuário.</param>
        Task Register(RegisterDto dto);

        /// <summary>
        /// Realiza o login de um usuário no sistema.
        /// </summary>
        /// <param name="dto">O modelo contendo as credenciais do usuário.</param>
        Task Login(LoginDto dto);
    }
}