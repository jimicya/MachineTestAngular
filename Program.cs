
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoanManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials(); 
                });
            });

            // Add services to the container
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use default naming policy
                    options.JsonSerializerOptions.WriteIndented = true; // Format JSON output
                });

            // Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            // Configure the DbContext with the connection string
            builder.Services.AddDbContext<LoanManagementDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            // Register repositories
            builder.Services.AddScoped<ILoginRepository, LoginRepository>(); 

            // Configure Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("AllowAllOrigin");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}

