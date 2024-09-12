using Microsoft.EntityFrameworkCore;
using SpendWise.Domain.Entities;

namespace SpendWise.Infrastructure.DataAcess
{
     public class SpendWiseDbContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        
        public SpendWiseDbContext(DbContextOptions<SpendWiseDbContext> options)
            : base(options)
        {
        }
    }
}