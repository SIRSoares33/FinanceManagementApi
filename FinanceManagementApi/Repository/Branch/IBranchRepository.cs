using FinanceManagementApi.Models.Branch;

namespace FinanceManagementApi.Repository.Branch
{
    public interface IBranchRepository
    {
        Task CreateBranchAsync(BranchModel branchModel);
        Task DeleteBranchAsync(int branchId);
        Task UpdateBranchAsync(int branchId, BranchModel branchModel);
        Task<BranchModel> GetBranchByIdAsync(int id);
        Task<List<BranchModel>> GetAllBranchsByUserIdAsync(int userId);
    }
}