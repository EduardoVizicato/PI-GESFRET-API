using System;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Responses.User
{
    public record RegisterUserResponse
    {
        
        public string FirstName { get; init; }
        
        public string LastName { get; init; }
        
        public string Email { get; init; }
        
        public TaxIdVO TaxId { get; init; }
        
        public string PhoneNumber { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}