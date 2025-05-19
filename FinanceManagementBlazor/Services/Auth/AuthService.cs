using Finance.Dtos;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Login;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Register;
using FinanceManagementBlazor.Services.JwtParser;

namespace FinanceManagementBlazor.Services.Auth.Login;

public class AuthService(ILoginHttpService loginHttpService, IRegisterHttpService registerHttpService, IJwtParser jwtParser, AuthProvider authProvider) : IAuthService
{
    public async Task Login(LoginDto dto)
    {
        var token = await loginHttpService.LoginHttpRequest(dto);

        await authProvider.UserLoggedIn(jwtParser.GetLoggedUserModel(token), token);
    }
    
    public async Task Register(RegisterDto dto) 
        => await registerHttpService.RegisterHttpRequest(dto);
}