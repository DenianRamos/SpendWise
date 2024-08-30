using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using SpendWise.Communication.Enums;
using SpendWise.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public  class RequestRegisterExpenseJsonBuilder
    {
        public static RequestExpenseJson Build()
        {

           return  new Faker<RequestExpenseJson>()
                .RuleFor(r => r.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(r => r.Title, faker => faker.Lorem.Sentence())
                .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max:1000))
                .RuleFor(r => r.Date, faker => faker.Date.Past())
                .RuleFor(r => r.PaymentType, faker => faker.PickRandom<EPaymentType>());
        }
    }
}
