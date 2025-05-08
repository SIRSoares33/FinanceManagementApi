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

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();

#region Services
    builder.Services.AddScoped<IAuthService, AuthService>();

    #region Models
    builder.Services.AddScoped<AuthModel>();
    #endregion

    #region HttpRequests Services
    // Endpoints
    builder.Services.AddScoped<IAuthEndpoints, AuthEndpoints>();
    builder.Services.AddScoped<IServerEndpoint, ServerEndpoint>();
    // Requests
    builder.Services.AddScoped<ILoginHttpService, LoginHttpService>();
    builder.Services.AddScoped<IRegisterHttpService, RegisterHttpService>();
    #endregion

    #region Storage
    builder.Services.AddScoped<IUserLoggedStorage, UserLoggedStorage>();
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
