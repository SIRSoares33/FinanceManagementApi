using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.HttpRequests.Branch
{
    public interface IBranchHttpService
    {
        Task<List<BranchModel>> GetAllBranchsAsync();
        Task DeleteBranchAsync(string id);
        Task CreateBranch(BranchModel model);
    }
}