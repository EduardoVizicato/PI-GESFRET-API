using TMS.Domain.Entities;
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

    [Fact]
    public void Should_User_Register_ResultOK()
    {
        var firstName = "Eduardo";
        var lastName = "Silva";
        EmailVO email = new EmailVO("vizicato@gmail.com");
        PasswordVO password = new PasswordVO("Eduardo1234");
        TaxIdVO taxId = new TaxIdVO("45567790088");
        PhoneVO phoneNumber = new PhoneVO("15997421213");
        
        var user = new User(firstName, lastName, email, password, taxId, phoneNumber);
        
        Assert.Equal(firstName, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(email, user.Email);
        Assert.Equal(password, user.Password);
        Assert.Equal(taxId, user.TaxId);
        Assert.Equal(phoneNumber, user.PhoneNumber);
    }
}