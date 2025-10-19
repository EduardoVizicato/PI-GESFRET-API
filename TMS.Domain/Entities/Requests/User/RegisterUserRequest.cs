using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Requests.User
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(string firstName, string lastName, string email, string password, string phoneNumber, TaxIdVO taxId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            TaxId = taxId;
        }

        [Required]
        public string FirstName { get; private set; }

        [Required]
        public string LastName { get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        [Required]
        public TaxIdVO TaxId { get; private set; }
    }
}
