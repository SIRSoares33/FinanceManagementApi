using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.JwtParser
{
    /// <summary>
    /// Define os métodos para analisar e extrair informações de um token JWT.
    /// </summary>
    public interface IJwtParser
    {
        /// <summary>
        /// Obtém o modelo do usuário logado a partir de um token JWT.
        /// </summary>
        /// <param name="token">O token JWT a ser analisado.</param>
        /// <returns>Um <see cref="LoggedUserModel"/> contendo as informações do usuário logado.</returns>
        LoggedUserModel GetLoggedUserModel(string token);
    }
}