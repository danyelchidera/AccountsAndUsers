using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersForAccountAsync(Guid accountID, bool trackChanges);
        Task<User> GetUserForAccountById(Guid accountID, Guid userId, bool trackChanges);
        Task CreateUser(User user); 
        Task DeleteUser(User user);
    }
}
