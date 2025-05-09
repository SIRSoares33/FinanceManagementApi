using FinanceManagementBlazor.Entities;

namespace FinanceManagementBlazor.Services.HttpRequests.Branch
{
    public interface IBranchHttpService
    {
        Task<List<BranchModel>> GetAllBranchs();
    }
}