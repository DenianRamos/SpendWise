using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using SpendWise.Domain.Security;
using SpendWise.Domain.Security.Criptography;
using SpendWise.Domain.User;
using SpendWise.Exception.ExceptionBase;

namespace SpendWise.Application.UseCase.Login
{
    public  class LoginUseCase : ILoginUseCase

    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAcessTokenGenerator _accessTokenGenerator;

        public LoginUseCase(IUserReadOnlyRepository repository, IPasswordEncripter passwordEncripter, IAcessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
           var user = await _repository.GetByUserEmail(request.Email);
           if (user is null)
           {
               throw new InvalidLoginException();
           }
           var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if (passwordMatch is false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
