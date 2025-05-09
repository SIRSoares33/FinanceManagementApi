using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FinanceManagementBlazor;
using FinanceManagementBlazor.Services.Auth;
using FinanceManagementBlazor.Services.Auth.Login;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Login;
using FinanceManagementBlazor.Services.HttpRequests.Auth.Register;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.LoginEndpoints;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.AuthEndpoints;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using FinanceManagementBlazor.Entities;
using FinanceManagementBlazor.Services.HttpRequests.Endpoints.BaseEndpoint;
using FinanceManagementBlazor.Storage.Token;
using System.IdentityModel.Tokens.Jwt;
using FinanceManagementBlazor.Services.JwtParser;
using FinanceManagementBlazor.Services.HttpRequests.Branch;
using FinanceManagementBlazor.Entities.Endpoints.BranchEndpoints;
using FinanceManagementBlazor.Services.HttpRequests;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddBlazoredLocalStorage();

#region Services
    builder.Services.AddScoped<IAuthService, AuthService>();

    #region Http    
    builder.Services.AddSingleton(sp => new HttpClient
    {
        BaseAddress = new Uri(ServerEndpoint.Base)
    });
    builder.Services.AddScoped<IHttpService, HttpService>();
#endregion

#region Models
builder.Services.AddScoped<AuthModel>();
    #endregion

    #region HttpRequests Services
    // Endpoints
    builder.Services.AddScoped<IAuthEndpoints, AuthEndpoints>();
    builder.Services.AddScoped<IBranchEndpoints, BranchEndpoints>();
    // Requests
    builder.Services.AddScoped<ILoginHttpService, LoginHttpService>();
    builder.Services.AddScoped<IRegisterHttpService, RegisterHttpService>();
    // Branch
    builder.Services.AddScoped<IBranchHttpService, BranchHttpService>();

    builder.Services.AddScoped<IBranchHttpService, BranchHttpService>();
    #endregion

    #region Storage
    builder.Services.AddScoped<IUserLoggedStorage, UserLoggedStorage>();
    builder.Services.AddScoped<ITokenStorage, TokenStorage>();
#endregion

#region Auth
builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<AuthProvider>();
    builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<AuthProvider>());
    builder.Services.AddScoped<JwtSecurityTokenHandler>();
    builder.Services.AddScoped<IJwtParser, JwtParser>();
    #endregion

#endregion

await builder.Build().RunAsync();
