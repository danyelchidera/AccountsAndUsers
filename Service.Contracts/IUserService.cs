using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Dtos;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAccountUsersAsync(Guid accountId, bool trackAccountChanges, 
            bool trackUserChanges);
        Task<UserReadDto> GetAccountUserByIdAsync(Guid accountId, Guid userId, bool trackAccountChanges, 
            bool trackUserChanges);
        Task<UserReadDto> CreateAccountUser(Guid accountId, UserWriteDto userWriteDto, bool trackChange);
        Task UpdateAccountUser(Guid accountId, Guid userId, UserUpdateDto userUpdateDto, 
            bool trackAccountChanges, bool trackUserChanges);
        Task DeleteAccountUser(Guid accountId, Guid userId, bool trackAccountChanges,
            bool trackUserChanges);

    }
}
