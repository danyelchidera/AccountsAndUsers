﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AccountNotFoundException: NotFoundException
    {
        public AccountNotFoundException(Guid id)
            :base ($"Account with id: {id} not found.")

        {

        }
    }
}
