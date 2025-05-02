using FinanceManagementApi.Context;
using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository
{
    public class UserRepository(IContext context) : IUserRepository
    {
        #region Methods
        // IUserRepository
        public Task<UserModel?> Login(LoginModel model)
            => context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);   
            
        public async Task RegisterAsync(UserModel model)
        {
            if (await VerifyEmailExistsInDb(model.Email))
                throw new Exception("Email já existente.");

            await context.Users.AddAsync(model);   
            await context.Save();   
        }
        // Local
        private Task<bool> VerifyEmailExistsInDb(string email)
            => context.Users.AnyAsync(x => x.Email == email);
        #endregion
    }
}