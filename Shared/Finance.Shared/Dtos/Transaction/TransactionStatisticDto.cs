using System.Text.Json.Serialization;

namespace Finance.Dtos;

public class TransactionStatisticDto
{
    [JsonPropertyName("entry")]
    public decimal Entry { get; set; }
    [JsonPropertyName("expense")]
    public decimal Expense { get; set; }
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
}
