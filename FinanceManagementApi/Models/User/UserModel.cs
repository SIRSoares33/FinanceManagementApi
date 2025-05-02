using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManagementApi.Models.User
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage="Email é obrigatório.")]
        [EmailAddress(ErrorMessage="Email é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage="Senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;
    }
}