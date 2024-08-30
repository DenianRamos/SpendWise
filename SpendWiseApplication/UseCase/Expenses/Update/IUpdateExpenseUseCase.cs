using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Communication.Requests;
using SpendWise.Domain.Entities;

namespace SpendWise.Application.UseCase.Expenses.Update
{
     public  interface IUpdateExpenseUseCase
     {
        
         Task Execute(long id, RequestExpenseJson request);
     }
}
