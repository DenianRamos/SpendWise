using CommonTestUtilities.Requests;
using FluentAssertions;
using SpendWise.Application.UseCase.Users;
using SpendWise.Domain.User.ResourceErrors;

namespace Validators.Users
{
    public class RequestUserValidatorTest
    {
        [Fact]
        public void Sucess()
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("             ")]
        public void Error_Name_Invalid(string name)
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage == ResourceUserValidate.NAME_INVALID);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("             ")]
        public void Error_Name_Empty(string name)
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage == ResourceUserValidate.NAME_EMPTY);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("             ")]
        public void Error_Email_Empty(string email)
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = email;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage == ResourceUserValidate.EMAIL_EMPTY);
        }

        [Fact]
        public void Error_Email_Invalid()
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = "invalid-email";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.ErrorMessage == ResourceUserValidate.EMAIL_INVALID);
        }

        [Fact]
        public void Error_Password_Empty()
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Password = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage == ResourceUserValidate.PASSWORD_INVALID);
        }
    }
}