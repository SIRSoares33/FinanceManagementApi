using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;

namespace FinanceManagementBlazor.Services.Home
{
    public interface IHomeService
    {
        Task<HomeDependecies> GetHomeDependencies();
        Task DeleteBranchAsync(string branchId);
        Task SaveBranchAsync(BranchModel branchInfo);
    }
}
