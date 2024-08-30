using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Communication.Responses;

namespace SpendWise.Application.UseCase.Expenses.Delete
{
     public interface IDeleteExpenseUseCase

    {
        Task Execute(long id);
    }
}
