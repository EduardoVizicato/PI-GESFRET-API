using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Requests.Travel
{
    public class TravelRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AddressVO Origin { get; set; }
        public AddressVO Destination { get; set; }
        public LoadVO Load { get; set; }
        public decimal Price { get; set; }
        public Guid VehicleId { get; set; }
    }
}
