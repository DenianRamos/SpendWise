using AutoMapper;
using SpendWise.Application.UseCase.Users;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Repositories;
using SpendWise.Domain.Security;
using SpendWise.Domain.Security.Criptography;
using SpendWise.Domain.User;
using SpendWise.Domain.User.ResourceErrors;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Application.UseCase.Expenses.Register.User
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUserReadOnlyRepository _userRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitForWork _UnitOfWork;
        private readonly IAcessTokenGenerator _accessTokenGenerator;

        public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter, IUserReadOnlyRepository userRepository, IUserWriteOnlyRepository userWriteOnly,
            IUnitForWork unitForWork, IAcessTokenGenerator accessTokenGenerator)
        {
            _accessTokenGenerator = accessTokenGenerator;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _userRepository = userRepository;
            _userWriteOnlyRepository = userWriteOnly;
            _UnitOfWork = unitForWork;


        }


        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);
            user.UserIdentify = Guid.NewGuid();

            await _userWriteOnlyRepository.AddUser(user);

            await _UnitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)

            };
        }


        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceUserValidate.EMAIL_EMPTY));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
