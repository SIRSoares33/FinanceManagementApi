using FinanceManagementApi.Context;
using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository
{
    public class UserRepository(IContext context) : IUserRepository
    {
        public Task<UserModel?> Login(LoginModel model)
            => context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);   
    }
}