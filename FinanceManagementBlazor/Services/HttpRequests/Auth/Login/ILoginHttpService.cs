using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Login
{
    /// <summary>
    /// Define o serviço responsável por realizar requisições HTTP relacionadas ao login.
    /// </summary>
    public interface ILoginHttpService
    {
        /// <summary>
        /// Realiza a requisição HTTP para autenticação de login.
        /// </summary>
        /// <param name="loginModel">Modelo contendo as credenciais de login.</param>
        /// <returns>Uma string representando a resposta da requisição.</returns>
        Task<string> LoginHttpRequest(AuthModel loginModel);
    }
}