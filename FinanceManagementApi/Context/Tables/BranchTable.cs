using System.ComponentModel.DataAnnotations;

namespace FinanceManagementApi.Context.Tables;

public class BranchTable
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CreatedAt { get; set; }
    public int UserId { get; set; }
    public UserTable? User { get; set; }
    public ICollection<TransactionTable> Transactions { get; set; } = null!;
}