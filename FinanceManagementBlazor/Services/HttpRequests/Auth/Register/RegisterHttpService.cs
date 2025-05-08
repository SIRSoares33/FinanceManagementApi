using System.Net.Http.Json;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Register
{
    public class RegisterHttpService(HttpClient http, IAuthEndpoints endpoint) : IRegisterHttpService
    {
        public async Task RegisterHttpRequest(AuthModel authModel)
        {
            var response = await http.PostAsJsonAsync(endpoint.Register, new { authModel.Name, authModel.Email, authModel.Password });
            
            if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}