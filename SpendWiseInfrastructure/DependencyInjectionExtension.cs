using Microsoft.Extensions.DependencyInjection;
using SpendWise.Domain.Repositories;
using SpendWise.Infrastructure.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SpendWise.Infrastructure
{
   public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitForWork, UnitForWork>();
            services.AddScoped<IExpenseReadOnlyRepository, ExpenseRepository > ();
            services.AddScoped<IExpenseWriteOnlyRepository, ExpenseRepository>();
            services.AddScoped<IExpenseUpdateOnlyRepository, ExpenseRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection"); ;

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));
        
            services.AddDbContext<SpendWiseDbContext>( configure => configure.UseMySql(connectionString, serverVersion) );
     
        }
    };
}
