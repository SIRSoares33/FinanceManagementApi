using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Services.Token
{
    /// <summary>
    /// Interface para gerar tokens de autenticação
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Gera um token para authenticação
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateToken(UserModel user);
    }
}