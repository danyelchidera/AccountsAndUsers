using System.ComponentModel.DataAnnotations;

namespace Utility.Dtos
{
    public abstract class AccountManipulationDto
    {
#nullable disable
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(128, ErrorMessage = "Company name cannot be more than 128 character")]
        public string CompanyName { get; set; }
#nullable enable
        public string? Website { get; set; }
    }

}
