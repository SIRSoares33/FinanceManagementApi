using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finance.Dtos;

public class TransactionDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório required")]
    [StringLength(20, ErrorMessage = "Nome deve ter no máximo 20 caracteres")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = "Sem descrição.";

    [StringLength(10, ErrorMessage = "Categoria deve ter no máximo 10 caracteres")]
    [JsonPropertyName("category")]
    public string Category { get; set; } = "None";

    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Tipo de transação é obrigatório")]
    [JsonPropertyName("isEntry")]
    public bool IsEntry { get; set; }
    public string TransactionDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

    [Required(ErrorMessage = "Id da branch é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Id da branch deve ser maior que zero")]
    [JsonPropertyName("branchId")]
    public int BranchId { get; set; }
}
