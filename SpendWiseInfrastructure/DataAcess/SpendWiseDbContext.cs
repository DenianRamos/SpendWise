using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise.Domain.Entities;

namespace SpendWise.Infrastructure.DataAcess
{
    internal class SpendWiseDbContext : DbContext
    {
        public SpendWiseDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Expense> Expenses { get; set; }


    }
}
