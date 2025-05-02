using FinanceManagementApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IContext
    {
        public DbSet<UserModel> Users { get; set; }
        public Task Save()
            => SaveChangesAsync();
    }
}