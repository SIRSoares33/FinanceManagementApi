using System.Net.Http.Json;
using Finance.Dtos;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Login;

public class LoginHttpService(IHttpService httpService, IAuthEndpoints endpoint) : ILoginHttpService
{
    #region HTTP
    private readonly HttpClient _http = httpService.GetHttpClient(false);
    #endregion

    #region Methods
    public async Task<string> LoginHttpRequest(LoginDto dto)
    {
        var response = await _http.PostAsJsonAsync(endpoint.Login, dto);
        var content  = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode is false) throw new Exception(content);

        return content; // This is the JWT token.
    }
    #endregion
}