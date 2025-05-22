using System.ComponentModel.DataAnnotations;

namespace FinanceManagementApi.Context.Tables;

public class TransactionTable
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Amount { get; set; }
    public bool IsEntry { get; set; }
    public DateTime TransactionDate { get; set; }
    public int BranchId { get; set; }
    public BranchTable? Branch { get; set; }
}
