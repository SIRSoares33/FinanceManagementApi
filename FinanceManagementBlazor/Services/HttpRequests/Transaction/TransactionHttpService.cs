using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Finance.Dtos;
using FinanceManagementBlazor.Entities.Endpoints.Transaction;

namespace FinanceManagementBlazor.Services.HttpRequests.Transaction;

public class TransactionHttpService(IHttpService httpService, ITransactionEndpoints endpoint) : ITransactionHttpService
{
    #region Http
    private readonly HttpClient _http = httpService.GetHttpClient(true);
    #endregion

    #region Methods
    public async Task<TransactionStatisticDto> GetStatisticAsync(int? id)
    {
        var thisEndpoint = id is null ? endpoint.GetAllStatistic : endpoint.GetBranchStatistic + id;    

        var respose = await _http.GetAsync(thisEndpoint);
        var content = await respose.Content.ReadAsStringAsync();

        if (respose.IsSuccessStatusCode is false) throw new Exception(content);

        return JsonSerializer.Deserialize<TransactionStatisticDto>(content)
            ?? throw new Exception("Erro ao desserializar json");
    }

    public async Task<List<TransactionDto>> GetTransactionsAsync(int branchId)
    {
        var response = await _http.GetAsync(endpoint.GetAll + branchId);
        var content  = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode is false) throw new Exception(content);

        return JsonSerializer.Deserialize<List<TransactionDto>>(content) 
                ?? throw new Exception("Fala ao deserializar json"); 
    }
    public async Task AddTransactionAsync(TransactionDto model)
    {
        var response = await _http.PostAsJsonAsync(endpoint.AddTransaction, model);

        if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
    }
    public async Task RemoveTransactionAsync(int id)
    {
        var response = await _http.DeleteAsync(endpoint.Delete + id.ToString());

        if (response.IsSuccessStatusCode is false) throw new Exception(await response.Content.ReadAsStringAsync());
    }
    #endregion
}

public class TransactionStatisticModel
{
    [JsonPropertyName("entry")]
    public decimal Entry { get; set; }
    [JsonPropertyName("expense")]
    public decimal Expense { get; set; }
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
}
