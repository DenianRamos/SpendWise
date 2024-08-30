using FluentValidation;
using SpendWise.Communication.Requests;
using SpendWise.Exception;

namespace SpendWise.Application.UseCase.Expenses
{
    public class ExpenseValidation : AbstractValidator<RequestExpenseJson>
    {
        public ExpenseValidation()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);

            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_ERROR);

            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATE_ERROR);

            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_INVALID);


        }
    }
}
