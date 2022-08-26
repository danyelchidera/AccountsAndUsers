using Contracts;
using Entities;
using Service.Contracts;

namespace Services
{
    internal sealed class AccountService: IAccountService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        public AccountService(IRepositoryManager repository, ILoggerManager logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts(bool trackChanges) =>
            await _repository.Account.GetAllAccounts(trackChanges);

      
    }
}