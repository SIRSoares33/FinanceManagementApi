using System.Text;
using FinanceManagementApi.Context;
using FinanceManagementApi.Models.User;
using FinanceManagementApi.Repository;
using FinanceManagementApi.Repository.Branch;
using FinanceManagementApi.Repository.Transaction;
using FinanceManagementApi.Repository.User;
using FinanceManagementApi.Services.Auth;
using FinanceManagementApi.Services.Login;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Swagger
builder.Services.AddSwaggerGen();
#endregion

#region Context
builder.Services.AddDbContext<IContext, AppDbContext>(x => x.UseSqlite("DataSource=app.db"));
#endregion

#region Config
// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ModelState error Configuration
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var primeiroErro = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .FirstOrDefault();

        return new UnprocessableEntityObjectResult(primeiroErro);
    };
});
#endregion

#region Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtSecretKey")!))
        };
    });
#endregion

#region DI
// Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchExists, BranchRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
// TokenService
builder.Services.AddSingleton<ITokenService, TokenJwtService>();
//AuthService
builder.Services.AddScoped<IAuthService, AuthService>();
// PasswordHasher
builder.Services.AddSingleton<IPasswordHasher<IUserEmailAndPassword>, PasswordHasher<IUserEmailAndPassword>>();
#endregion

var app = builder.Build();

#region Middlewares
    // Controllers
    app.MapControllers();
    // Auth
    app.UseAuthentication();
    app.UseAuthorization();
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
#endregion

app.Run();