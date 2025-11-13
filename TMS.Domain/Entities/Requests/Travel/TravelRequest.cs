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
        public TravelRequest(DateTime startDate, DateTime endDate, AddressVO origin, AddressVO destination, LoadVO load, decimal price, Guid truckId)
        {
            StartDate = startDate;
            EndDate = endDate;
            Origin = origin;
            Destination = destination;
            Load = load;
            Price = price;
            TruckId = truckId;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public AddressVO Origin { get; private set; }
        public AddressVO Destination { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public Guid TruckId { get; private set; }
    }
}
