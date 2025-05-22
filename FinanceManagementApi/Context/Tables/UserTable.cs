using System.ComponentModel.DataAnnotations;

namespace FinanceManagementApi.Context.Tables;

public class UserTable
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<BranchTable> Branches { get; set; } = [];
}