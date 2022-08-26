﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UserNotFoundException: NotFoundException
    {
        public UserNotFoundException(Guid id)
            :base($"User with id: {id} not found.")
        {

        }
    }
}
