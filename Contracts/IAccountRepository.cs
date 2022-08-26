using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts(bool trackChanges);
        Task<Account?> GetAccountAsync(Guid id, bool trackChanges);
        Task CreateAccount(Account account);
        Task DeleteAccountAsync(Account account);
    }
}
