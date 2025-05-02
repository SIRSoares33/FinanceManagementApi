using FinanceManagementApi.Models.Login;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Repository.User;
using FinanceManagementApi.Services.Auth;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Identity;

namespace FinanceManagementApi.Services.Login
{
    public class AuthService(IUserRepository repository, ITokenService tokenService, IPasswordHasher<IUserEmailAndPassword> hasher)
        : IAuthService
    {
        public async Task<string?> LoginAsync(LoginModel model)
        {
            var user = await repository.GetUserByEmail(model.Email);

            if (user is null)
                return null;

            return hasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Success
            ? tokenService.GenerateToken(user) : null;
        }

        public async Task RegisterAsync(UserModel model)
        {
            if (await repository.VerifyEmailExistsInDb(model.Email))
                throw new Exception("Email já existente.");
        
            model.Password = hasher.HashPassword(model, model.Password);

            await repository.AddUserAsync(model);
        }

        public async Task DeleteAsync(int id) 
        {
            var userToDelete = await repository.GetUserById(id) 
                ?? throw new Exception("Não foi possível localizar o usuário para exclusão.");
            
            await repository.DeleteUserAsync(userToDelete);
        }
    }
}