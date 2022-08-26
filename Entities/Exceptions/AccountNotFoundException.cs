using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AccountNotFoundException: NotFoundException
    {
        public AccountNotFoundException(Guid id)
            :base ($"The company with id: {id} doesn't exist in the database.")

        {

        }
    }
}
