using System.Security.Claims;
using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Identity;

namespace FinanceManagementApi.Services.Auth;

public class AuthService(IRepository repository, ITokenService tokenService, IPasswordHasher<UserTable> hasher, IMapper mapper)
    : IAuthService
{
    public async Task<string?> LoginAsync(LoginDto dto)
    {
        try
        {
            var user = await repository.GetByAsync<UserTable>(u => u.Email == dto.Email);

            return hasher.VerifyHashedPassword(user, user.Password, dto.Password) == PasswordVerificationResult.Success
            ? tokenService.GenerateToken(user) : null;
        }
        catch (KeyNotFoundException) { return null; }
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        if (await repository.ExistsAsync<UserTable>(x => x.Email == dto.Email))
            throw new Exception("Email já existente.");
    
        dto.Password = hasher.HashPassword(new(), dto.Password);

        await repository.CreateAsync(mapper.Map<UserTable>(dto));
    }

    public async Task DeleteAsync(ClaimsPrincipal user) 
        => await repository.DeleteAsync<UserTable>(UserIdentity.UserIdentity.GetUserId(user));
}