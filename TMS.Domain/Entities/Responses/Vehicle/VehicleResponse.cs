using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites.Responses.Vehicle
{
    public class VehicleResponse
    {
        public string Name { get; set; }
        public VehicleRegistrationPlateVO VehicleRegistrationPlate { get; set; }
        public VehicleType Type { get; private set; }
        public RodadoEnum Rodado { get; private set; }
        public CarroceriaEnum Carroceria { get; private set; }
    }
}
