using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Login;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Register;
using FinanceManagementBlazor.Services.JwtParser;

namespace FinanceManagementBlazor.Services.Auth.Login
{
    public class AuthService(ILoginHttpService loginHttpService, IRegisterHttpService registerHttpService, IJwtParser jwtParser, AuthProvider authProvider) : IAuthService
    {
        public async Task Login(AuthModel authModel)
        {
            var token = await loginHttpService.LoginHttpRequest(authModel);

            await authProvider.UserLoggedIn(jwtParser.GetLoggedUserModel(token));
        }
        
        public async Task Register(AuthModel authModel) 
            => await registerHttpService.RegisterHttpRequest(authModel);
    }
}