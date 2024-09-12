using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Application.UseCase.Expenses.Register.User
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
