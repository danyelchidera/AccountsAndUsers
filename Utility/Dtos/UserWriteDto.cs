using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Validations;

namespace Utility.Dtos
{
    public class UserWriteDto: UserManipulationDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [UniqueEmail]
        public string Email { get; set; }
    }
}
