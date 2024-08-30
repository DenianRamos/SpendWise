using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SpendWise.Communication.Responses;
using SpendWise.Domain.Repositories;
using SpendWise.Exception;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Application.UseCase.Expenses.GetById
{
     public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IExpenseReadOnlyRepository _expenseRepository;

        private readonly IMapper _mapper;


        public GetExpenseByIdUseCase(IExpenseReadOnlyRepository expenseRepository, IMapper mapper)
        {
                _expenseRepository = expenseRepository;
                _mapper = mapper;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var result = await _expenseRepository.GetById(id);
            if (result == null)
            {

                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_fOUND);
            }
            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
