using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Utility.Dtos;

namespace Services
{
    internal sealed class AccountService: IAccountService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AccountReadDto> CreateAccountAsync(AccountWriteDto accountWriteDto)
        {
            var account = _mapper.Map<Account>(accountWriteDto);
            await _repository.Account.CreateAccount(account);
            await _repository.Save();

            return _mapper.Map<AccountReadDto>(account);
        }

        public async Task DeleteAccountAsync(Guid id, bool trackChanges)
        {
            var account = await _repository.Account.GetAccountAsync(id, trackChanges);
            if (account == null)
                throw new AccountNotFoundException(id);
            

            await _repository.Account.DeleteAccountAsync(account);
            await _repository.Save();   
        }

        public async Task<SingleAccountReadDto> GetAccountAsync(Guid id, bool trackChanges)
        {
            
            var account = await _repository.Account.GetAccountAsync(id, trackChanges);

            if(account == null)
                throw new AccountNotFoundException(id);

            return _mapper.Map<SingleAccountReadDto>(account);
        }

        public async Task<IEnumerable<AccountReadDto>> GetAllAccounts(bool trackChanges)
        {
            var accounts = await _repository.Account.GetAllAccounts(trackChanges);
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }

        public async Task UpdateAccount(Guid id, AccountUpdateDto accountUpdateDto, bool trackChanges)
        {
            var account = await _repository.Account.GetAccountAsync(id, trackChanges);
            if(account == null)
                throw new AccountNotFoundException(id);

            _mapper.Map(accountUpdateDto, account);
            await _repository.Save();
        }
    }
}