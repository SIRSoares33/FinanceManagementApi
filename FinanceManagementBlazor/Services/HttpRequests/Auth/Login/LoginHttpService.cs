using System.Net.Http.Json;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Login
{
    public class LoginHttpService(IHttpService httpService, IAuthEndpoints endpoint) : ILoginHttpService
    {
        private readonly HttpClient _http = httpService.GetHttpClient(false);

        public async Task<string> LoginHttpRequest(AuthModel loginModel)
        {
            var response = await _http.PostAsJsonAsync(endpoint.Login, new { loginModel.Email, loginModel.Password });
            var content  = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode is false) throw new Exception(content);

            return content; // This is the JWT token.
        }
    }
}