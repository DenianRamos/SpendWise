using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Domain.User
{
  public interface IUserWriteOnlyRepository
    {
        Task AddUser(Entities.User user);

    }
}
