using SpendWise.Domain.Entities;

namespace SpendWise.Domain.Repositories
{
    public interface IExpenseUpdateOnlyRepository
    {

        Task<Expense?> GetById (long id);
        void update (Expense expense);
    }
}
