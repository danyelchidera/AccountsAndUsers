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

        public async Task<IEnumerable<Account>> GetAllAccounts(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(x => x.CompanyName)
            .ToListAsync();
    }
}
