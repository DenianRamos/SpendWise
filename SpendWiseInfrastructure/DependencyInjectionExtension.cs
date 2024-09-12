using Microsoft.Extensions.DependencyInjection;
using SpendWise.Domain.Repositories;
using SpendWise.Infrastructure.DataAcess.Repositories;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpendWise.Domain.Security;
using SpendWise.Domain.Security.Criptography;
using SpendWise.Infrastructure.Security.Tokens;
using IAcessTokenGenerator = SpendWise.Domain.Security.IAcessTokenGenerator;
using SpendWise.Domain.User;
using SpendWise.Infrastructure.DataAcess;

namespace SpendWise.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
            AddToken(services, configuration);

            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitForWork, UnitForWork>();
            services.AddScoped<IExpenseReadOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpenseWriteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpenseUpdateOnlyRepository, ExpenseRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<int>("Settings:Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAcessTokenGenerator>(x => new AcessTokenGenerator((uint)expirationTimeMinutes, signingKey));
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

            services.AddDbContext<SpendWiseDbContext>(configure => configure.UseMySql(connectionString, serverVersion));
        }
    }
}