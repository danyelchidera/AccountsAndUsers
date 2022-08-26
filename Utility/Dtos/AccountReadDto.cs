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
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(128, ErrorMessage = "Company name cannot be grater than 128 characters")]
        public string CompanyName { get; set; }
#nullable enable
        public string? Website { get; set; }
    }
}
