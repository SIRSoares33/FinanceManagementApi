using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.Branch;

public interface IBranchService
{
    Task<BranchViewDependencies> GetBranchViewDependenciesAsync();
    Task SaveTransactionAsync(TransactionModel model);
    Task DeleteTransactionAsync(int id);
}
