using System.Net.Http.Headers;
using System.Net.Http.Json;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Login
{
    public class LoginHttpService(HttpClient http, IAuthEndpoints endpoint) : ILoginHttpService
    {
        public async Task<string> LoginHttpRequest(AuthModel loginModel)
        {
            var response = await http.PostAsJsonAsync(endpoint.Login, new { loginModel.Email, loginModel.Password });
            var content  = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode is false) throw new Exception(content);

            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content);

            return content; // This is the JWT token.
        }
    }
}