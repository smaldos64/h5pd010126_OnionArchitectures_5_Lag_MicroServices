
using Audit.Application.Interfaces;
using Audit.Application.Services;
using Audit.Domain.Services.Interfaces;
using Audit.Infrastructure.Persistence;
using Audit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Audit.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var connectionString = builder.Configuration.GetConnectionString("MyBankDatabase") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<BankDbContext>(opt => opt.UseMySql(ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly("Audit.Infrastructure")));
            // MySQL
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
            builder.Services.AddDbContext<TransactionDbContext>(dbContextOptions => dbContextOptions
                            .UseMySql(connectionString, serverVersion, x => x.MigrationsAssembly("MyBank.Infrastructure.Persistence.MySQL"))
                            // The following three options help with debugging, but should
                            // be changed or removed for production.
                            .LogTo(Console.WriteLine, LogLevel.Information)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors()
                            );

            builder.Services.AddScoped<IAuditAppService, AuditAppService>();
            builder.Services.AddScoped<IAuditRepository, AuditRepository>();
            
            builder.Services.AddSwaggerGen(c => {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
