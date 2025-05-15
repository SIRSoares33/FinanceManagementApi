namespace FinanceManagementBlazor.Storage.Token
{
    public interface ITokenStorage : ILocalStorageManager<string>
    {
        /// <summary>
        /// Pega o token de forma síncrona.
        /// </summary>
        /// <returns></returns>
        string? GetItem();
    }
}
