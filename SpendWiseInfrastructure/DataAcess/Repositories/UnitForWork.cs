using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using SpendWise.Domain.Repositories;

namespace SpendWise.Infrastructure.DataAcess.Repositories
{
     internal  class UnitForWork : IUnitForWork
    {
        private readonly SpendWiseDbContext _dbContext;

            public UnitForWork(SpendWiseDbContext dbContext)
        {
             _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }

}
