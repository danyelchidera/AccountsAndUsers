using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repository, logger));
            _userService = new Lazy<IUserService>(() => new UserService(repository, logger));
        }
        public IAccountService AccountService => _accountService.Value;

        public IUserService UserService => _userService.Value;
    }
}
