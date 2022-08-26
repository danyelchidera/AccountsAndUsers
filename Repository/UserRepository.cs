using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context)
            : base(context)
        {

        }

        public Task CreateUser(User user)
        {
            Create(user);
            return Task.CompletedTask;
        }

        public Task DeleteUser(User user)
        {
            Delete(user);
            return Task.CompletedTask;
        }

        public async Task<User?> GetUserForAccountById(Guid accountID, Guid userId, bool trackChanges)=>
            await FindByCondition(c => c.Id.Equals(userId) && c.AccountId.Equals(accountID), trackChanges)
                .FirstOrDefaultAsync();
        

        public async Task<IEnumerable<User>> GetUsersForAccountAsync(Guid accountID, bool trackChanges)=>
            await FindByCondition(c => c.AccountId.Equals(accountID), trackChanges)
                .ToListAsync();
    }
}
