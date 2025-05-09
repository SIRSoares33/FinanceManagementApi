using System.Text.Json.Serialization;

namespace FinanceManagementBlazor.Entities
{
    public class BranchModel
    {
        [JsonPropertyName("	id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonPropertyName("transactions")]
        public ICollection<TransactionModel>? Transactions { get; set; } = [];
    }
}