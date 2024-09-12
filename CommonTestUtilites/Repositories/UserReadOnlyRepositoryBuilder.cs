using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SpendWise.Domain.User;

namespace CommonTestUtilities.Repositories
{
    public  class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder()
        {
                _repository = new Mock<IUserReadOnlyRepository>();
        }

        public void ExistActiveUserWithEmail(string email)
        {
            _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
        }

      public IUserReadOnlyRepository Build() => _repository.Object;

    }
}
