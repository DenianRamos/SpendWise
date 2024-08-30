using SpendWise.Communication.Responses;

namespace SpendWise.Application.UseCase.Expenses.GetById
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    }
}
