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

        public string Name { get; private set; }
        public string Email { get; private set; }
        public TaxIdVO TaxId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Vehicle> Vehicles { get; set; }

        public void UpdateEnterprise(string name, string email, TaxIdVO taxId)
        {
            Name = name;
            Email = email;
            TaxId = taxId;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
