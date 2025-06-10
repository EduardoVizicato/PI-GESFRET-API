using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Domain.Entities.Interfaces;
using TMS.Domain.ValueObjects;

public class UserModel : IdentityUser<Guid>, IBaseEntity
{
    private UserModel() { }
    
    public UserModel(string firstName, string lastName, EmailVO email, TaxIdVO taxId, PhoneVO phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        PhoneVO = phoneNumber;
        CreatedAt = DateTime.UtcNow;
        SetEmail(email);
        SetPhoneNumber(phoneNumber);
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public TaxIdVO TaxId { get; private set; } // This is mapped via your EntityTypeConfiguration
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [NotMapped]
    public EmailVO EmailVO { get; private set; }
    [NotMapped]
    public PhoneVO PhoneVO { get; private set; }
    public void UpdateUser(string firstName, string lastName, EmailVO email, TaxIdVO taxId, PhoneVO phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        TaxId = taxId;
        UpdatedAt = DateTime.UtcNow;
        SetEmail(email);
        SetPhoneNumber(phoneNumber);
    }
    private void SetEmail(EmailVO email)
    {
        EmailVO = email;
        base.Email = email.Value;
        base.UserName = email.Value; 
        base.NormalizedEmail = email.Value.ToUpperInvariant(); 
        base.NormalizedUserName = email.Value.ToUpperInvariant(); 
    }
    
    private void SetPhoneNumber(PhoneVO phoneNumber)
    {
        PhoneVO = phoneNumber;
        base.PhoneNumber = phoneNumber.Value;
    }
}