using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace PI_TMS.DomainTests;

public class LoadTest
{
    public DescriptionVO Description { get; private set; }
    public float Quantity { get; private set; }
    public TypeVO Type { get; private set; }
    
    [Fact]
    public void Should_Load_Register_ResultOK()
    {

    }
}