using System.Text.Json.Serialization;

namespace FinanceManagementBlazor.Entities
{
    public class AuthModel
    {
        [JsonPropertyName("name")]	
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}