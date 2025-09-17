using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Requests.Travel
{
    public class TravelRequest
    {
        public string TravelName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public DescriptionVO Description { get; set; }
        public LoadVO Load { get; set; }
    }
}
