using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Validations;

namespace Utility.Dtos
{
    public abstract class UserManipulationDto
    {
#nullable disable
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(128, ErrorMessage = "First name cannot be more than 128 character")]
        public string FirstName { get; set; }

#nullable enable
        [MaxLength(128, ErrorMessage = "First name cannot be more than 128 character")]
        public string? LastName { get; set; }
    }
}
