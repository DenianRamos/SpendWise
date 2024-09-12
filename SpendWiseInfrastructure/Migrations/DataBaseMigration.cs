using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.Infrastructure.DataAcess;
using static System.Formats.Asn1.AsnWriter;

namespace SpendWise.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public async static Task MigrateDataBase(IServiceProvider serviceProvider)
        {
            var dbcontext = serviceProvider.GetRequiredService<SpendWiseDbContext>();

            await dbcontext.Database.MigrateAsync();
        }
        
    }
}
