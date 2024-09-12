using FluentValidation;
using SpendWise.Communication.Requests;
using SpendWise.Domain.User.ResourceErrors;


namespace SpendWise.Application.UseCase.Users
{
    public  class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceUserValidate.NAME_EMPTY);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceUserValidate.EMAIL_EMPTY).EmailAddress()
                .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator).WithMessage(ResourceUserValidate.EMAIL_INVALID);

            RuleFor(x => x.Password)
                .SetValidator(new PasswordValidator<RequestRegisterUserJson>())
                .When(user => !string.IsNullOrWhiteSpace(user.Name) &&
                              !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
