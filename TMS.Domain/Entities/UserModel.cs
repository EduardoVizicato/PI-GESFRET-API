using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

public class UserModel : IdentityUser<Guid>
{
    
    public UserModel(string firstName, string lastName, TaxIdVO taxId)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        CreatedAt = DateTime.UtcNow;
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public TaxIdVO TaxId { get; private set; }
    
    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public void UpdateUser(string firstName, string lastName, TaxIdVO taxId)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        UpdatedAt = DateTime.UtcNow;
    }
}