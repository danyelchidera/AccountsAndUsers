using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Dtos;

namespace Utility.Validations
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        public string error = "Email already exists"; 
        protected override ValidationResult? IsValid(
      object? value, ValidationContext validationContext)
        {
            var user = (UserWriteDto)validationContext.ObjectInstance;
            var repo = (RepositoryContext)validationContext
                         .GetService(typeof(RepositoryContext));

            if (repo.Users.Any(x => x.Email.Equals(user.Email)))
            {
                return new ValidationResult(error);
            }

            return ValidationResult.Success;
        }
    }
}
