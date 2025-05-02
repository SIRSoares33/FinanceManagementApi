using FinanceManagementApi.Context;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository;

public class UserRepository(IContext context) : IUserRepository
{
    #region Methods
    // IUserRepository
    public Task<UserModel?> GetUserByEmail(string email)
        => context.Users.FirstOrDefaultAsync(x => x.Email == email);
    
    public Task<UserModel?> GetUserById(int id)
        => context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public Task<bool> VerifyEmailExistsInDb(string email)
        => context.Users.AnyAsync(x => x.Email == email);
    
    public async Task AddUserAsync(UserModel model)
    {
        await context.Users.AddAsync(model);
        await context.Save();   
    }       

    public async Task DeleteUserAsync(UserModel userToDelete)
    {
        context.Users.Remove(userToDelete);
        await context.Save();
    }
    #endregion
}