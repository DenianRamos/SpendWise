using CommonTestUtilities.Requests;
using FluentAssertions;
using SpendWise.Application.UseCase.Expenses;
using SpendWise.Application.UseCase.Expenses.Register;
using SpendWise.Communication.Enums;
using SpendWise.Communication.Requests;
using SpendWise.Exception;

namespace Validators.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //arrange
            var validator = new ExpenseValidation();
            var request = RequestRegisterExpenseJsonBuilder.Build();


            //act
            var result = validator.Validate(request);

                
                result.IsValid.Should().BeTrue();


        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("                 ")]
        public void Error_Title_Empty(string title)
        {
            var validator = new ExpenseValidation();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = title;


            //act
            var result = validator.Validate(request);


            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(f => f.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }
        [Fact]
        public void Error_Date_Future()
        {
            var validator = new ExpenseValidation();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Date = DateTime.Now.AddDays(1);


            //act
            var result = validator.Validate(request);


            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(f => f.ErrorMessage.Equals(ResourceErrorMessages.DATE_ERROR));
        }

        [Fact]
        public void Error_Payment_Invalid()
        {
            var validator = new ExpenseValidation();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.PaymentType = (EPaymentType)700;


            //act
            var result = validator.Validate(request);


            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(f => f.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_INVALID));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]

        public void Error_Amount_Invalid(decimal amount)
        {
            var validator = new ExpenseValidation();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;


            //act
            var result = validator.Validate(request);


            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(f => f.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_ERROR));
        }


    }
}
