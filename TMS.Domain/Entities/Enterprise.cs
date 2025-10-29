using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMS.Domain.Entites;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entities
{
    public class Enterprise : BaseEntity
    {
        public Enterprise(string name,string email, TaxIdVO taxId) { 
            Name = name;
            Email = email;
            TaxId = taxId;
            CreatedAt = DateTime.UtcNow;    
            IsActive = true;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public TaxIdVO TaxId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public void UpdateEnterprise(string name, string email, TaxIdVO taxId)
        {
            Name = name;
            Email = email;
            TaxId = taxId;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
