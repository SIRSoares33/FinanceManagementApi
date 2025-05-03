using FinanceManagementApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Context
{
    public interface IContext
    {
        DbSet<UserModel> Users { get; set; }
        Task Save();
    }
}