using System.Text.Json.Serialization;

namespace FinanceManagementBlazor.Entities
{
    public class TransactionModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("description")]
        public string Description { get; set; } = "Sem descrição.";
        

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("isEntry")]
        public bool IsEntry { get; set; }

        [JsonPropertyName("transactionDate")]
        public string TransactionDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        [JsonPropertyName("branchId")]
        public int BranchId { get; set; }
    }
}