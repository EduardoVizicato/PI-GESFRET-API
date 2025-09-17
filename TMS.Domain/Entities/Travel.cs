using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites
{
    public class Travel : BaseEntity
    {
        public Travel(string travelName, 
            DateTime startDate, 
            DateTime endDate,
            decimal price,
            DescriptionVO description,
            LoadVO load
            )
        {
            TravelName = travelName;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Description = description;
            Load = load;
            TravelStatus = TravelStatus.Todo;
            CreatedAt = DateTime.Now;
        }
        public string TravelName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public TravelStatus TravelStatus { get; private set; }
        public DescriptionVO Description { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }

        public void UpdateTravel(
            string travelName, 
            DateTime startDate, 
            DateTime endDate,
            float weight,
            decimal price,
            DescriptionVO description
            )
        {
            TravelName = travelName;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Description = description;
            UpdatedAt = DateTime.Now;
        }

        private static Dictionary<TravelStatus, TravelStatus> _nextStatus = new()
        {
            { TravelStatus.Todo, TravelStatus.InProgress },
            { TravelStatus.InProgress, TravelStatus.Done },
        };

        public void CancelTravel()
        {
            if (TravelStatus == TravelStatus.Done)
            {
                throw new InvalidOperationException("Cannot cancel a done travel.");
            }
            TravelStatus = TravelStatus.Cancelled;
        }

        public void AdvanceStatus()
        {
            if (TravelStatus == TravelStatus.Cancelled)
            {
                throw new InvalidOperationException("Cannot advance a cancelled travel.");
            }

            if (!_nextStatus.TryGetValue(TravelStatus, out var next))
            {
                throw new InvalidOperationException("No next status available.");
            }
            
            TravelStatus = next;
        }
    }
}
