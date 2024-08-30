using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;

namespace SpendWise.Application.UseCase.Expenses.Register
{
    public interface IRegisterExpenseUseCase
    {
        Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson request);
    }
}
