using System.Net.Http.Headers;
using FinanceManagementBlazor.Storage.Token;

namespace FinanceManagementBlazor.Services.HttpRequests;

public class HttpService(ITokenStorage tokenStorage, HttpClient http) : IHttpService
{
    #region IIHttpService Methods
    public HttpClient GetHttpClient(bool withAuthHeader)
    {
        if (withAuthHeader)
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenStorage.GetItem());
            
        return http;
    }
    #endregion
}


public interface IHttpService
{
    /// <summary>
    /// Retorna uma instância de HtttpClient com ou sem autenticação.
    /// </summary>
    /// <param name="withAutgh"></param>
    /// <returns></returns>
    HttpClient GetHttpClient(bool withAutgh);
}