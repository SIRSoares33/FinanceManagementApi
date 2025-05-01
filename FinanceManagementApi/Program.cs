var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Port Configuration
#endregion

#region Swagger
builder.Services.AddSwaggerGen();
#endregion

#region Context
#endregion

#region DI
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