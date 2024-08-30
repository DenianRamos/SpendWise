using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SpendWise.Application.UseCase.Expenses.Register;
using SpendWise.Communication.Requests;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Repositories;
using SpendWise.Exception;
using SpendWise.Exception.ExceptionBase;


namespace SpendWise.Application.UseCase.Expenses.Update
{
     public class UpdateExpenseUseCase : IUpdateExpenseUseCase
     {
         private readonly IMapper _mapper;

         private readonly IUnitForWork _unitForWork;

         private readonly IExpenseUpdateOnlyRepository _repository;

         public UpdateExpenseUseCase(IMapper mapper, IUnitForWork unitForWork, IExpenseUpdateOnlyRepository repository)
         {
                _mapper = mapper;
                _unitForWork = unitForWork;
                _repository = repository;
         }



         public async Task Execute(long id, RequestExpenseJson request)
         {
            Validate(request);

            var expense = await _repository.GetById(id);

            if (expense is null)
            {
                throw new SystemException(ResourceErrorMessages.EXPENSE_NOT_fOUND);
            }

            _mapper.Map(request, expense);

            _repository.update(expense);

            await _unitForWork.Commit();
         }

         private void Validate(RequestExpenseJson request) 
         {
             var validator = new ExpenseValidation();
             var result = validator.Validate(request);
             if (result.IsValid == false)
                {
                    var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                    throw new ErrorOnValidationException(errorMessages);
                }

         }
         
            
     }
}
