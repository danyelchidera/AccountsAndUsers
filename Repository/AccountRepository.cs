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
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext context) 
            : base(context)
        {
        }

        public Task CreateAccount(Account account)
        {
            Create(account);
            return Task.CompletedTask;
        }

        public Task DeleteAccountAsync(Account account)
        {
            Delete(account);
            return Task.CompletedTask;
        }

        public async Task<Account?> GetAccountAsync(Guid id, bool trackChanges)=>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(x => x.Users)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Account>> GetAllAccounts(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(x => x.CompanyName)
            .ToListAsync();
    }
}
