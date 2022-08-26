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
        Task<IEnumerable<UserReadDto>> GetAccountUsersAsync(Guid accountId, bool trackChanges);
        Task<UserReadDto> GetAccountUserByIdAsync(Guid accountId, Guid userId, bool trackChanges);

    }
}
