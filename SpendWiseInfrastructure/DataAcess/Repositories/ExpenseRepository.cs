using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Repositories;

namespace SpendWise.Infrastructure.DataAcess.Repositories
{
   internal class ExpenseRepository : IExpenseReadOnlyRepository, IExpenseWriteOnlyRepository, IExpenseUpdateOnlyRepository

    {
        private readonly SpendWiseDbContext _dbContext;
        public ExpenseRepository(SpendWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Expense expense)
        {
        await _dbContext.Expenses.AddAsync(expense);
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.Expenses.Remove(result);

            return true;
        }

        public async Task<List<Expense>> GetAll()
        {
          return await  _dbContext.Expenses.AsNoTracking().ToListAsync();
        }

        async Task<Expense?> IExpenseReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Expense>> FilterByMonth(DateOnly date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var endDate = new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59);

            return await _dbContext
                .Expenses
                .AsNoTracking()
                .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
                .OrderBy(expense => expense.Date)
                .ToListAsync();
        }

        async Task<Expense?> IExpenseUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }



        public void update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }
    }
}
