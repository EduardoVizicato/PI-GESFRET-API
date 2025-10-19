using System;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Responses.User
{
    public record RegisterUserResponse
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public TaxIdVO TaxId { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}