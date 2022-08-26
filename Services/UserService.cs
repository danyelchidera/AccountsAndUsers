using AutoMapper;
using Contracts;
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

        public Task<UserReadDto> GetAccountUserByIdAsync(Guid accountId, Guid userId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserReadDto>> GetAccountUsersAsync(Guid accountId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
