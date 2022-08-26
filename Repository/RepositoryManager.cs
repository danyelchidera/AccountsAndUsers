using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<UserRepository> _userRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _userRepository = new Lazy<UserRepository>(() => new UserRepository(context));
        }
        public IAccountRepository Account => _accountRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
