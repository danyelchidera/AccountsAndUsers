using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Dtos
{
    public class AccountReadDto
    {
#nullable disable
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
#nullable enable
        public string? Website { get; set; }
    }
}
