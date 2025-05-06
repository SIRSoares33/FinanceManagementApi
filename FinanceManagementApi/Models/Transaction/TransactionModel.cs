using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FinanceManagementApi.Models.Branch;

namespace FinanceManagementApi.Models.Transaction
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nome é obrigatório required")]
        [StringLength(20, ErrorMessage = "Nome deve ter no máximo 20 caracteres")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres")]
        public string Description { get; set; } = "Sem descrição.";
        
        [StringLength(10, ErrorMessage = "Categoria deve ter no máximo 10 caracteres")]
        public string Category { get; set; } = "None";
        
        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Tipo de transação é obrigatório")]
        public bool IsEntry { get; set; }

        public string TransactionDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

        public int BranchId { get; set; }

        [JsonIgnore]
        public BranchModel? Branch { get; set; }
    }
}