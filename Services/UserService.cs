using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Dtos;

namespace Services
{
    internal sealed class UserService: IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> CreateAccountUser(Guid accountId, UserWriteDto userWriteDto, bool trackChange)
        {
            await AccountExists(accountId, trackChange);

            var user = _mapper.Map<User>(userWriteDto);
            user.AccountId = accountId; 
            await _repository.User.CreateUser(user);
            await _repository.Save();

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task DeleteAccountUser(Guid accountId, Guid userId, bool trackAccountChanges, bool trackUserChanges)
        {
            await AccountExists(accountId, trackAccountChanges);
            var user = await UserExists(accountId, userId, trackUserChanges);
            await _repository.User.DeleteUser(user);
            await _repository.Save();
        }

        public async Task<UserReadDto> GetAccountUserByIdAsync(Guid accountId, Guid userId, bool trackAccountChanges, bool trackUserChanges)
        {
            await AccountExists(accountId, trackAccountChanges);
            var user = await UserExists(accountId, userId, trackUserChanges);
            return _mapper.Map<UserReadDto>(user);

        }

        public async Task<IEnumerable<UserReadDto>> GetAccountUsersAsync(Guid accountId, bool trackAccountChanges, bool trackUserChanges)
        {
            await AccountExists(accountId, trackAccountChanges);
            var users = await _repository.User.GetUsersForAccountAsync(accountId, trackUserChanges);
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task UpdateAccountUser(Guid accountId,Guid userId, UserUpdateDto userUpdateDto, 
            bool trackAccountChanges, bool trackUserChanges)
        {
            await AccountExists(accountId, trackAccountChanges);
            var user = await UserExists(accountId, userId, trackUserChanges);
            _mapper.Map(userUpdateDto, user);
            await _repository.Save();
        }

        private async Task AccountExists(Guid accountId, bool trackChanges)
        {
            var account = await _repository.Account.GetAccountAsync(accountId, trackChanges);
            if (account == null)
                throw new AccountNotFoundException(accountId);
        }

        private async Task<User> UserExists(Guid accountId, Guid userId, bool trackChanges)
        {
            var user = await _repository.User.GetUserForAccountById(accountId, userId, trackChanges);
            if (user == null)
                throw new UserNotFoundException(userId);
            return user;
        }

    }
}
