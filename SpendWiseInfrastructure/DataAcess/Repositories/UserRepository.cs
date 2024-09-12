using SpendWise.Domain.User;
using Microsoft.EntityFrameworkCore;
using SpendWise.Domain.Entities;

namespace SpendWise.Infrastructure.DataAcess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly SpendWiseDbContext _dbContext;

         public UserRepository(SpendWiseDbContext dbContext)
        {
           _dbContext = dbContext;
        }


        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetByUserEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }
    }
}