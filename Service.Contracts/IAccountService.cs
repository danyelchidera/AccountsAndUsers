﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts(bool trackChanges);

    }
}