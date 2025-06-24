using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entities.Requests.Adress;

public class AddressRequest
{
    public StreetVO Street { get; private set; }
    public CityVO City { get; private set; }
    public StateVO State { get; private set; }
    public PostalCodeVO PostalCode { get; private set; }
    public int AdressNumber { get; private set; }
    public Guid TravelId { get; set; }
}