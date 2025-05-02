using System.ComponentModel.DataAnnotations;

namespace FinanceManagementApi.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email é obrigatório.")]
        [EmailAddress(ErrorMessage="Email é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage="Senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;
    }
}