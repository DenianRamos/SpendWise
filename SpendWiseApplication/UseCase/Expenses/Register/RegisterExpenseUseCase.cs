using AutoMapper;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Repositories;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Application.UseCase.Expenses.Register
{
    public class RegisterExpenseUseCase :  IRegisterExpenseUseCase
    {
        private readonly IUnitForWork _unitforwork;
        private readonly IExpenseWriteOnlyRepository _repository;
        private readonly IMapper _mapper;
       
        
        public RegisterExpenseUseCase(IExpenseWriteOnlyRepository repository , IUnitForWork unitforwork, IMapper mapper)
        {
            _repository = repository;
            _unitforwork = unitforwork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson request)
        {
            try
            {
                Validate(request);
                var entity = _mapper.Map<Expense>(request);
                await _repository.Add(entity);
                await _unitforwork.Commit();
                return _mapper.Map<ResponseRegisterExpenseJson>(entity);
            }
            catch (System.Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
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
