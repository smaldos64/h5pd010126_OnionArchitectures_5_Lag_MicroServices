
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Account.Application.Interfaces;
using Account.Application.Services;
using Account.Domain.Services.Interfaces;
using Account.Domain.Services.Services;
using Account.Infrastructure.Persistence;
using Account.Infrastructure.Repositories;
using Account.Infrastructure.ExternalServices;

namespace MyBank.WebApi
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
            builder.Services.AddDbContext<BankDbContext>(opt => opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("Account.Infrastructure")));
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountAppService, AccountAppService>();
            builder.Services.AddScoped<TransferDomainService>();

            builder.Services.AddHttpClient<IAuditIntegrationService, AuditIntegrationService>
                (client => { client.BaseAddress = new Uri("https://localhost:7001/"); });

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
