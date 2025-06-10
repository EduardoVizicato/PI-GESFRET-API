using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace PI_TMS.DomainTests;

public class UserTest
{
    [Fact]
    public void Should_User_Register_ResultOK()
    {
        var firstName = "Eduardo";
        var lastName = "Silva";
        var email = new EmailVO("vizicato@gmail.com");
        var taxId = new TaxIdVO("45567790088");
        var phoneNumber = new PhoneVO("15997421213");
        
        var user = new UserModel(firstName, lastName, email, taxId, phoneNumber);
        
        Assert.Equal(firstName, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(email, user.EmailVO);
        Assert.Equal(taxId, user.TaxId);
        Assert.Equal(phoneNumber, user.PhoneVO);
    }
}