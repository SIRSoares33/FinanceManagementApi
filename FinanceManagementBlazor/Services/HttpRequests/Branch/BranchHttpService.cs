using System.Net.Http.Json;
using System.Text.Json;
using Finance.Dtos;
using FinanceManagementBlazor.Entities.Endpoints.BranchEndpoints;

namespace FinanceManagementBlazor.Services.HttpRequests.Branch;

public class BranchHttpService(IHttpService httpService, IBranchEndpoints endpoint) : IBranchHttpService
{
    #region Http
    private readonly HttpClient _http = httpService.GetHttpClient(true);
    #endregion

    #region Methods
    public async Task<List<BranchDto>> GetAllBranchsAsync()
    {
        var response = await _http.GetAsync(endpoint.GetAll);
        var content  = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode is false) throw new Exception(content);

        return JsonSerializer.Deserialize<List<BranchDto>>(content) 
            ?? throw new Exception("Não foi possível desserializar a resposta do servidor.");
    }
    public async Task DeleteBranchAsync(string id)
    {
        var response = await _http.DeleteAsync(endpoint.Delete + id);

        if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
    }
    public async Task CreateBranch(BranchDto model)
    {
        var response = await _http.PostAsJsonAsync(endpoint.Create, new { model.Name, model.Description });

        if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
    }
    #endregion
}