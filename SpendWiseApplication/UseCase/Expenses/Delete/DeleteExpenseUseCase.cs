using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Domain.Repositories;
using SpendWise.Exception;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Application.UseCase.Expenses.Delete
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly  IExpenseWriteOnlyRepository _repository;
        private readonly IUnitForWork _unitOfWork;

        public DeleteExpenseUseCase(IExpenseWriteOnlyRepository repository, IUnitForWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
             var result = await _repository.Delete(id);
            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_fOUND);
            }

            await _unitOfWork.Commit();

           
        }
    }
}
