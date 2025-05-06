using FinanceManagementApi.Context;
using FinanceManagementApi.Models.Branch;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository.Branch
{
    public class BranchRepository(IContext context) : IBranchRepository
    {
        #region Methods
        // IBranchRepository
        public async Task CreateBranchAsync(BranchModel branchModel)
        {
            await context.Branches.AddAsync(branchModel);
            await context.Save();
        }

        public async Task DeleteBranchAsync(int branchId)
        {
            var branchToDelete = await GetBranchByIdAsync(branchId);

            context.Branches.Remove(branchToDelete);
            await context.Save();
        }

        public async Task UpdateBranchAsync(int branchId, BranchModel branchModel)
        {
            await DeleteBranchAsync(branchId);

            branchModel.Id = branchId;
            
            await context.Branches.AddAsync(branchModel);
            await context.Save();
        }

        public async Task<BranchModel> GetBranchByIdAsync(int id)
        {
            return await context.Branches
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Branch não encontrada.");
        }

        public async Task<List<BranchModel>> GetAllBranchsByUserIdAsync(int userId)
        {
            var user = await context.Users
                .Include(x => x.Branches)
                .FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception("Usuário não encontrado.");

            return user.Branches.ToList();
        }
        #endregion
    }
}