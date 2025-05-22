using FinanceManagementApi.Context.Tables;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserTable> Users { get; set; }
    public DbSet<BranchTable> Branches { get; set; }
    public DbSet<TransactionTable> Transactions { get; set; }
}