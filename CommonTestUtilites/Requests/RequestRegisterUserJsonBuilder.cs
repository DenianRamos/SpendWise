using Bogus;
using SpendWise.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public  class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build()
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(r => r.Name, faker => faker.Name.FirstName())
                .RuleFor(r => r.Email, (faker, r) => faker.Internet.Email(r.Name))
                .RuleFor(r => r.Password, faker => faker.Internet.Password(prefix:"!Aa1"))
                .Generate();
        }
    }
}
