using TMS.Domain.Entites;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entities;

public class Address : BaseEntity
{
    public Address()
    {
        
    }
    public Address(StreetVO street, CityVO city, StateVO state, PostalCodeVO postalCode, int adressNumber)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        AdressNumber = adressNumber;
    }
    public StreetVO Street { get; private set; }
    public CityVO City { get; private set; }
    public StateVO State { get; private set; }
    public PostalCodeVO PostalCode { get; private set; }
    public int AdressNumber { get; private set; }
    public Guid TravelId { get; set; }
    public Travel Travel { get; set; }

    public void Update(StreetVO street, CityVO city, StateVO state, PostalCodeVO postalCode, int adressNumber)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        AdressNumber = adressNumber;
    }
}