using FinanceManagementApi.Context.Tables;

namespace FinanceManagementApi.Services.Token
{
    /// <summary>
    /// Interface para gerar tokens de autenticação
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Gera um token para authenticação com as claims do usuário.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateToken(UserTable user);
    }
}