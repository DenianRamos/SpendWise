using SpendWise.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SpendWise.Domain.Repositories;

namespace SpendWise.Application.UseCase.Expenses.GetAll
{
    public class GetAllExpenseUseCase : IGetAllExpenseUseCase
    {

        private readonly IMapper _mapper;
        private readonly IExpenseReadOnlyRepository _expensesRepositories;
        public GetAllExpenseUseCase(IExpenseReadOnlyRepository expensesRepositories, IMapper mapper)
        {
            _expensesRepositories = expensesRepositories;
            _mapper = mapper;
        }

        public async  Task<ResponsesExpensesJson> Execute()
        {
            var result = await _expensesRepositories.GetAll();
            return new ResponsesExpensesJson()
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
            };
        }
    }
}
