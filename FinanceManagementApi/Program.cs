using System.Text;
using FinanceManagementApi.Context;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Controllers.ControllerServices.Branch;
using FinanceManagementApi.Controllers.ControllerServices.Transaction;
using FinanceManagementApi.Repository;
using FinanceManagementApi.Services.Auth;
using FinanceManagementApi.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        #region Swagger
        builder.Services.AddSwaggerGen();
        #endregion

        #region Context
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite("DataSource=app.db"));
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
        builder.Services.AddScoped<IRepository, Repository>();
        // TokenService
        builder.Services.AddSingleton<ITokenService, TokenJwtService>();
        //AuthService
        builder.Services.AddScoped<IAuthService, AuthService>();
        //BranchService
        builder.Services.AddScoped<IBranchService, BranchService>();
        // PasswordHasher
        builder.Services.AddSingleton<IPasswordHasher<UserTable>, PasswordHasher<UserTable>>();
        // TransactionService
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        // AutoMapper
        builder.Services.AddAutoMapper(typeof(Program));
        #endregion

        var app = builder.Build();

        #region Middlewares
        // CORS
        app.UseCors("AllowAllOrigins");
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
    }
}

#region Swagger

#endregion
#region Context

#endregion
#region Config

#endregion
#region Authentication

#endregion
#region DI

#endregion

#region Middlewares

#endregion
