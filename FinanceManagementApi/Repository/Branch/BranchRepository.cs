using FinanceManagementApi.Context;
using FinanceManagementApi.Context.Tables;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository.Branch
{
    public class BranchRepository(IContext context) : IBranchRepository
    {
        #region Methods
        // IBranchRepository
        public async Task CreateBranchAsync(BranchTable branchModel)
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

        public async Task UpdateBranchAsync(int branchId, BranchTable branchModel)
        {
            await DeleteBranchAsync(branchId);

            branchModel.Id = branchId;
            
            await context.Branches.AddAsync(branchModel);
            await context.Save();
        }

        public async Task<BranchTable> GetBranchByIdAsync(int id)
        {
            return await context.Branches
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Branch não encontrada.");
        }

        public async Task<List<BranchTable>> GetAllBranchsByUserIdAsync(int userId)
        {
            var user = await context.Users
                .Include(x => x.Branches)
                .ThenInclude(x => x.Transactions)
                .FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception("Usuário não encontrado.");

            return user.Branches.ToList();
        }
        // IBranchExists
        public async Task BranchExistsAsync(int branchId) 
        {
            bool exists = await context.Branches.AnyAsync(x => x.Id == branchId);
            
            if (!exists) throw new Exception("Branch não encontrada.");
        }
        #endregion
    }
}