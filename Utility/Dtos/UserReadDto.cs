using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Dtos
{
    public class UserReadDto
    {
#nullable disable
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Guid AccountId { get; set; }
#nullable enable
        public string? LastName { get; set; }
    }
}
