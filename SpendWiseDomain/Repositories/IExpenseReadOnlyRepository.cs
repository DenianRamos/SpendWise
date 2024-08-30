using SpendWise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Domain.Repositories
{
    public  interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> GetAll();

        Task<Expense?> GetById(long id);
    }
}
