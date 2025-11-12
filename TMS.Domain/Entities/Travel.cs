using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites
{
    
    public class Travel
    {
        private Travel() { }
        public Travel(
            DateTime startDate, 
            DateTime endDate,
            AddressVO origin,
            AddressVO destination,
            decimal price,
            LoadVO load,
            Guid vehicleId)
        {
            StartDate = startDate;
            EndDate = endDate;
            Origin = origin;
            Destination = destination;
            Price = price;
            Load = load;
            CreatedAt = DateTime.Now;
            IsCanceled = false;
            VehicleId = vehicleId;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public AddressVO Origin { get; private set; }
        public AddressVO Destination { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public Guid VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsCanceled { get; private set; }

        public void UpdateTravel(
            DateTime startDate, 
            DateTime endDate,
            AddressVO origin,
            AddressVO destination,
            decimal price,
            LoadVO load
            
            )
        {
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Load = load;
            Origin = origin;
            Destination = destination;
            UpdatedAt = DateTime.Now;
        }

        public void CancelTravel()
        {
            if (IsCanceled)
            {
                throw new Exception("Travel is already canceled.");
            }

            IsCanceled = true;
        }
    }
}
