using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace PI_TMS.DomainTests;

public class AddressTest
{
    public StreetVO Street { get; private set; }
    public CityVO City { get; private set; }
    public StateVO State { get; private set; }
    public PostalCodeVO PostalCode { get; private set; }
    public int AdressNumber { get; private set; }

    [Fact]
    public void Should_Adress_Register_ResultOK()
    {
        StreetVO street = new StreetVO("Rua Ernesto Ferrari");
        CityVO city = new CityVO("Taquaritinga");
        StateVO state = new StateVO("SP");
        PostalCodeVO postalCode = new PostalCodeVO("12345678");
        int adressNumber = 123;
        
        var adress = new Address(street, city, state, postalCode, adressNumber);
        Assert.Equal(street, adress.Street);
        Assert.Equal(city, adress.City);
        Assert.Equal(state, adress.State);
        Assert.Equal(postalCode, adress.PostalCode);
        Assert.Equal(adressNumber, adress.AdressNumber);
    }
}