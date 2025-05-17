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
using FinanceManagementBlazor.Services.Home;
using FinanceManagementBlazor.Services.HttpRequests.Transaction;
using FinanceManagementBlazor.Entities.Endpoints.Transaction;
using FinanceManagementBlazor.Storage.Branch;
using FinanceManagementBlazor.Services.Branch;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddBlazoredLocalStorage();

#region Services
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IHomeService, HomeService>();
    builder.Services.AddScoped<IBranchService, BranchService>();

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
    builder.Services.AddScoped<ITransactionEndpoints, TransactionEndpoints>();
    // Requests
    builder.Services.AddScoped<ILoginHttpService, LoginHttpService>();
    builder.Services.AddScoped<IRegisterHttpService, RegisterHttpService>();
    // Branch
    builder.Services.AddScoped<IBranchHttpService, BranchHttpService>();
    // Transaction
    builder.Services.AddScoped<ITransactionHttpService, TransactionHttpService>();
    builder.Services.AddScoped<ITransactionEndpoints, TransactionEndpoints>();
    #endregion

    #region Storage
    builder.Services.AddScoped<IUserLoggedStorage, UserLoggedStorage>();
    builder.Services.AddScoped<ITokenStorage, TokenStorage>();
    builder.Services.AddScoped<IBranchStorage, BranchStorage>();
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
