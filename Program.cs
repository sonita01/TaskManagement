using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Repositories;
using TaskManagement.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["Key"] ?? throw new InvalidOperationException("JWT Key is not configured");

// Add authentication with JWT Bearer
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,

//         ValidIssuer = jwtSettings["Issuer"],
//         ValidAudience = jwtSettings["Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),

//         ClockSkew = TimeSpan.FromMinutes(1)
//     };
//     options.Events = new JwtBearerEvents
//     {
//         OnAuthenticationFailed = context =>
//         {
//             Console.WriteLine($"JWT Authentication failed: {context.Exception.Message}");
//             return Task.CompletedTask;
//         },
//         OnTokenValidated = context =>
//         {
//             Console.WriteLine("JWT Token validated successfully.");
//             return Task.CompletedTask;
//         },
//         OnChallenge = context =>
//         {
//             Console.WriteLine($"JWT Challenge triggered: {context.ErrorDescription}");
//             return Task.CompletedTask;
//         }
//     };
// });
// builder.Services.AddAuthorization();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger/index.html");
            return;
        }
        await next();
    });
}

app.UseHttpsRedirection();
app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();
app.Run();
