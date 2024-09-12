using Moq;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Security;

namespace CommonTestUtilities.Token
{
    public class JwtTokenGeneratorBuilder
    {
        public static IAcessTokenGenerator Build()
        {
            var mock = new Mock<IAcessTokenGenerator>();

            mock.Setup(acessTokenGenerator => acessTokenGenerator.Generate(It.IsAny<User>())).Returns("Token");

            return mock.Object;
        }

    }
}
