using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FinanceManagementApi.Models.Branch;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Models.User 
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class UserModel : IUserEmailAndPassword
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

        [JsonIgnore]
        public ICollection<BranchModel> Branches { get; set; } = [];
    }
}