using System.Net.Http.Json;
using Finance.Dtos;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Auth.Register
{
    public class RegisterHttpService(IHttpService httpService, IAuthEndpoints endpoint) : IRegisterHttpService
    {
        private readonly HttpClient _http = httpService.GetHttpClient(false);

        public async Task RegisterHttpRequest(RegisterDto dto)
        {
            var response = await _http.PostAsJsonAsync(endpoint.Register, dto);
            
            if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}