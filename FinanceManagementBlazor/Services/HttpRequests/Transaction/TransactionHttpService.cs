using System.Text.Json;
using System.Text.Json.Serialization;
using FinanceManagementBlazor.Entities.Endpoints.Transaction;

namespace FinanceManagementBlazor.Services.HttpRequests.Transaction;

public class TransactionHttpService(IHttpService httpService, ITransactionEndpoints endpoint) : ITransactionHttpService
{
    #region Http
    private readonly HttpClient _http = httpService.GetHttpClient(true);
    #endregion

    #region Methods
    public async Task<TransactionStatisticModel> GetStatisticAsync(int id)
    {
        var respose = await _http.GetAsync(endpoint.GetStatistic + id);
        var content = await respose.Content.ReadAsStringAsync();

        if (respose.IsSuccessStatusCode is false) throw new Exception(content);


        return JsonSerializer.Deserialize<TransactionStatisticModel>(content)
            ?? throw new Exception("Erro ao desserializar json");
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
