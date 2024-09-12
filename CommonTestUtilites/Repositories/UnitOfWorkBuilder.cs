using Moq;
using SpendWise.Domain.Repositories;

namespace CommonTestUtilities.Repositories
{
    public class UnitOfWorkBuilder
    {
        public static IUnitForWork Build()
        {
            var mock = new Mock<IUnitForWork>();

            return mock.Object;
        }
    }
}
