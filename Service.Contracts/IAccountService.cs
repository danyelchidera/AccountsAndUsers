using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Dtos;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountReadDto>> GetAllAccounts(bool trackChanges);
        Task<SingleAccountReadDto> GetAccountAsync(Guid id, bool trackChanges);
        Task<AccountReadDto> CreateAccountAsync(AccountWriteDto account);
        Task UpdateAccount(Guid id, AccountUpdateDto accountUpdateDto, bool trackChanges);
        Task DeleteAccountAsync(Guid id, bool trackChanges);
    }
}
