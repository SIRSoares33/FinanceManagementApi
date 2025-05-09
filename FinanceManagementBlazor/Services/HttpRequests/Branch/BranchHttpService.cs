using System.Text.Json;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Entities.Endpoints.BranchEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Branch
{
    public class BranchHttpService(IHttpService httpService, IBranchEndpoints endpoint) : IBranchHttpService
    {
        #region Http
        private readonly HttpClient _http = httpService.GetHttpClient(true);
        #endregion

        #region Methods
        public async Task<List<BranchModel>> GetAllBranchs()
        {
            var response = await _http.GetAsync(endpoint.GetAll);
            var content  = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode is false) throw new Exception(content);

            return JsonSerializer.Deserialize<List<BranchModel>>(content) 
                ?? throw new Exception("Não foi possível desserializar a resposta do servidor.");
        }
        #endregion
    }
}