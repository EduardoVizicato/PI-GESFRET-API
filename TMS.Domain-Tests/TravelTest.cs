using TMS.Domain.Entities;
using TMS.Domain.Entities.Enums;
using TMS.Domain.ValueObjects;

namespace PI_TMS.DomainTests;

public class TravelTest
{
    public string TravelName { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public TravelStatus TravelStatus { get; private set; } = TravelStatus.Todo;
    public DateTime DateCreate { get; } = DateTime.Now;
    public Address Adress { get; private set; }
    public float Weight { get; private set; }
    public float Price { get; private set; }
    public DescriptionVO Description { get; private set; }
    public Load Load { get; private set; }
    
    [Fact]
    public void Should_Travel_Register_ResultOK()
    {
        
    }
}