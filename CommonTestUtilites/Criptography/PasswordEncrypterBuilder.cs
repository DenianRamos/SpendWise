using Moq;
using SpendWise.Domain.Security.Criptography;

namespace CommonTestUtilities.Criptography
{
    public  class PasswordEncrypterBuilder
    {
        public static IPasswordEncripter Build()
        {
            var mock = new Mock<IPasswordEncripter>();

            mock.Setup(passwordEncrypter => passwordEncrypter.Encrypt(It.IsAny<string>())).Returns("!$dsadsa");

            return mock.Object;
        }
    }
}
