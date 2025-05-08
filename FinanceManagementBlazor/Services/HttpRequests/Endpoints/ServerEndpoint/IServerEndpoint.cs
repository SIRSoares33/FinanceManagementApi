namespace FinanceManagementBlazor.Services.HttpRequests.Endpoints.BaseEndpoint
{
    /// <summary>
    /// Representa a estrutura base para um endpoint do servidor.
    /// Fornece a URL base para requisições HTTP.
    /// </summary>
    public interface IServerEndpoint
    {
        /// <summary>
        /// Obtém a URL base do endpoint do servidor.
        /// </summary>
        string Base { get; }
    }
}