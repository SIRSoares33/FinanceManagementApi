using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finance.Dtos;

public class BranchDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome da branch é obrigatório.")]
    [StringLength(20, ErrorMessage = "Nome deve ter no máximo 20 caracteres.")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres.")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = "Sem descrição.";

    public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

    [JsonIgnore]
    public int UserId { get; set; }
}