using FinanceManagementApi.Models.Branch;
using FinanceManagementApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Context
{
    public interface IContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<BranchModel> Branches { get; set; }
        
        Task Save();
    }
}