using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Requests.User
{
    public record RegisterUserRequest
    {
        [Required]
        public string FirstName { get; init; }

        [Required]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Required]
        public string PhoneNumber { get; init; }

        [Required]
        public string TaxId { get; init; }
    }
}
