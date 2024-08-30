using SpendWise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Domain.Repositories
{

  
    public interface IExpenseWriteOnlyRepository
    {
        Task Add(Expense expense);

        /// <summary>
        ///  This function return TRUE if the expense is deleted successfully
        /// </summary>

        Task<bool> Delete(long id);
    }
}
