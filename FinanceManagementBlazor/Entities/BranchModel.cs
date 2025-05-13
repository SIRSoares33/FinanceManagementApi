using System.Text.Json.Serialization;

namespace FinanceManagementBlazor.Entities
{
    public class BranchModel(string name, string description)
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = name;

        [JsonPropertyName("description")]
        public string Description { get; set; } = description;
        
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; } = string.Empty;
    }
}