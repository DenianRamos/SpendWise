using CommonTestUtilities.Criptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;
using SpendWise.Application.UseCase.Expenses.Register.User;
using SpendWise.Domain.User.ResourceErrors;
using SpendWise.Exception;
using SpendWise.Exception.ExceptionBase;

namespace UseCases.Tests.Users.Registers
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            
           var request = RequestRegisterUserJsonBuilder.Build();
           var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();

        

        }
        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var useCase = CreateUseCase();

            var act = async () => await useCase.Execute(request);

            var result = act.Should().ThrowAsync<ErrorOnValidationException>();

            result.Where(ex => ex.GetErrorList().Count ==  1 && ex.GetErrorList().Contains(ResourceUserValidate.NAME_EMPTY));
        }

        [Fact]
        public async Task Error_Email_Already_Existent()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(request.Email);

            var act = async () => await useCase.Execute(request);

            var result = act.Should().ThrowAsync<ErrorOnValidationException>();

            result.Where(ex => ex.GetErrorList().Count == 1 && ex.GetErrorList().Contains(ResourceUserValidate.EMAIL_ALREADY_REGISTRED));
        }
        private RegisterUserUseCase CreateUseCase(string? email = null )
        {
            var mapper = MapperBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var writeOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
            var passwordEncrypter = PasswordEncrypterBuilder.Build();
            var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
            var readOnlyRepository = new UserReadOnlyRepositoryBuilder().Build();

            if(string.IsNullOrWhiteSpace(email) == false)
            {
                readOnlyRepository.ExistActiveUserWithEmail(email);
            }
            return new RegisterUserUseCase(mapper,passwordEncrypter,readOnlyRepository,writeOnlyRepository,unitOfWork,jwtTokenGenerator);

        }

        
    }
}
