using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FinanceManagementApi.Models.Transaction;
using FinanceManagementApi.Models.User;

namespace FinanceManagementApi.Models.Branch
{
    public class BranchModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome da branch é obrigatório.")]
        [StringLength(20, ErrorMessage="Nome deve ter no máximo 20 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage="Descrição deve ter no máximo 100 caracteres.")]
        public string Description { get; set; } = "Sem descrição.";
        
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public int UserId { get; set; }

        [JsonIgnore]
        public UserModel? User { get; set; }

        public ICollection<TransactionModel>? Transactions { get; set; } = [];
    }
}