using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finance.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email é inválido.")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória.")]
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}