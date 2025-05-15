namespace FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints
{
    /// <summary>
    /// Define os endpoints relacionados à autenticação.
    /// Fornece as URLs base e específicas para operações de login.
    /// </summary>
    public interface IAuthEndpoints
    {
        /// <summary>
        /// Obtém a URL base dos endpoints de autenticação.
        /// </summary>
        string Base { get; }

        /// <summary>
        /// Obtém a URL do endpoint de login.
        /// </summary>
        string Login { get; }
        /// <summary>
        /// Obtém a URL do endpoint de registro.
        /// </summary>
        /// <returns>URL do endpoint de registro.</returns>
        string Register { get; }
    }
}