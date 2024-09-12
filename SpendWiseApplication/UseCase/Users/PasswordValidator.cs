using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using SpendWise.Domain.User.ResourceErrors;

namespace SpendWise.Application.UseCase.Users
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {

            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceUserValidate.PASSWORD_INVALID);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceUserValidate.PASSWORD_INVALID);
                return false;

            }
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceUserValidate.PASSWORD_INVALID);
                return false;
            }

            return true;
        }

        public override string Name { get; }
    }
}
