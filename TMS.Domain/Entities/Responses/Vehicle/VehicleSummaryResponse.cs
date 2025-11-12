using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;

namespace TMS.Domain.Entities.Responses.Vehicle
{
    public class VehicleSummaryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistrationPlate { get; set; } // exponha string, não o VO
        public VehicleType TruckType { get; set; }
        public RodadoEnum? WheelType { get; set; }
        public CarroceriaEnum? BodyType { get; set; }
    }
}
