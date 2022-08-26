using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
#nullable disable
        [Column("UserId")]
        public Guid Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

#nullable enable

        [MaxLength(128)]
        public string? LastName { get; set; }
#nullable disable
    }
}
