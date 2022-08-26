using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Account
    {
#nullable disable
        [Column("AccountId")]
        public Guid Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string CompanyName { get; set; }
#nullable enable
        public string? Website { get; set; }
#nullable disable
        public ICollection<User> Users { get; set; }

    }
}