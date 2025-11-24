using Microsoft.Identity.Client;
using TMS.Domain.Entites;
using TMS.Domain.ValueObjects;

namespace PI_TMS.API.Models.ViewModel
{
    public class TravelViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AddressVO Origin { get; set; }
        public AddressVO Destination { get; set; }
        public LoadVO Load { get; set; }
        public decimal Price { get; set; }
        public Guid EnterpriseId { get; set; }
        public Guid TruckId { get; set; }
        public IFormFile File { get; set; }
    }
}
