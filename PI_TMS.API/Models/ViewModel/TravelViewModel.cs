using TMS.Domain.Entites;
using TMS.Domain.ValueObjects;

namespace PI_TMS.API.Models.ViewModel
{
    public class TravelViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public AddressVO Origin { get; private set; }
        public AddressVO Destination { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsCanceled { get; private set; }
        public Guid TruckId { get; private set; }
        public VehicleViewModel Truck { get; set; }
    }
}
