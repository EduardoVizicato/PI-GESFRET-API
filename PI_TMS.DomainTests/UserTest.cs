using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;

namespace PI_TMS.DomainTests;

public class UserTest
{
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public TaxIdVO TaxId { get; private set; }
    public PhoneVO PhoneNumber { get; private set; }
    public EmailVO Email { get; set; }
    public PasswordVO Password { get; private set; }
    
    public UserRole UserRole { get; set; }
    
    
    public UserTest(string firstName, string lastName, EmailVO email, PasswordVO password, TaxIdVO taxId, PhoneVO phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        TaxId = taxId;
        PhoneNumber = phoneNumber;
    }

    [Fact]
    public void Should_User_Register_ResultOK()
    {
        
    }
}
