using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Requests.Vehicle
{
    public class VehicleRequest
    {
        public string Name { get; set; }
        public VehicleRegistrationPlateVO VehicleRegistrationPlate { get; set; }
        public VehicleType TruckType { get; private set; }
        public RodadoEnum WheelType { get; private set; }
        public CarroceriaEnum BodyType { get; private set; }
    }
}
