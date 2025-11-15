using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

public class UserModel : IdentityUser<Guid>
{
    
    public UserModel(string firstName, string lastName, TaxIdVO taxId, Guid enterpriseId)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        EnterpriseId = enterpriseId;
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public TaxIdVO TaxId { get; private set; }
    public bool IsActive { get; set; } = true;
    public DateTime? UpdatedAt { get; set; }

    public Guid EnterpriseId { get; set; }
    public Enterprise Enterprise { get; set; }

    public void UpdateUser(string firstName, string lastName, TaxIdVO taxId)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        UpdatedAt = DateTime.UtcNow;
    }
}