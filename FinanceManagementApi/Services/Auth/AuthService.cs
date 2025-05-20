using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository.User;
using FinanceManagementApi.Services.Auth;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Identity;

namespace FinanceManagementApi.Services.Login;

public class AuthService(IUserRepository repository, ITokenService tokenService, IPasswordHasher<UserTable> hasher)
    : IAuthService
{
    public async Task<string?> LoginAsync(UserTable table)
    {
        var user = await repository.GetUserByEmail(table.Email);

        if (user is null)
            return null;

        return hasher.VerifyHashedPassword(user, user.Password, table.Password) == PasswordVerificationResult.Success
        ? tokenService.GenerateToken(user) : null;
    }

    public async Task RegisterAsync(UserTable table)
    {
        if (await repository.VerifyEmailExistsInDb(table.Email))
            throw new Exception("Email já existente.");
    
        table.Password = hasher.HashPassword(table, table.Password);

        await repository.AddUserAsync(table);
    }

    public async Task DeleteAsync(int id) 
    {
        var userToDelete = await repository.GetUserById(id) 
            ?? throw new Exception("Não foi possível localizar o usuário para exclusão.");
        
        await repository.DeleteUserAsync(userToDelete);
    }
}