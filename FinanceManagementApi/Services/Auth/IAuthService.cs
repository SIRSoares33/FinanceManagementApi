using System.Security.Claims;
using Finance.Dtos;

namespace FinanceManagementApi.Services.Auth;

/// <summary>
/// Define os serviços de autenticação da aplicação, incluindo login, registro e exclusão de usuários.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Realiza o login de um usuário com base nas credenciais fornecidas.
    /// </summary>
    /// <param name="dto">Modelo contendo o email e a senha do usuário.</param>
    /// <returns>Token JWT gerado se as credenciais forem válidas; caso contrário, <c>null</c>.</returns>
    Task<string?> LoginAsync(LoginDto dto);

    /// <summary>
    /// Registra um novo usuário no sistema.
    /// </summary>
    /// <param name="dto">Modelo contendo os dados do novo usuário.</param>
    Task RegisterAsync(RegisterDto dto);

    /// <summary>
    /// Exclui um usuário com base no seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do usuário a ser excluído.</param>
    Task DeleteAsync(ClaimsPrincipal user);
}