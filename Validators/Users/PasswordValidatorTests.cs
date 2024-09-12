using CommonTestUtilities.Requests;
using FluentAssertions;
using FluentValidation;
using SpendWise.Application.UseCase.Users;
using SpendWise.Communication.Requests;
using SpendWise.Domain.User.ResourceErrors;

namespace Validators.Users
{
    public class PasswordValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("             ")]
        [InlineData("a")]
        [InlineData("aa")]
        [InlineData("aaa")]
        [InlineData("aaaa")]
        [InlineData("aaaaa")]
        [InlineData("aaaaaa")]
        [InlineData("aaaaaaa")]
        [InlineData("aaaaaaaa")]
        [InlineData("AAAAAAAA")]
        [InlineData("Aaaaaaaa")]
        [InlineData("Aaaaaaa1")]



        public void Error_Password(string password)
        {
            var validator = new PasswordValidator<RequestRegisterUserJson>();


            var result = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

          result.Should().BeFalse();
         
        }
    }
}
