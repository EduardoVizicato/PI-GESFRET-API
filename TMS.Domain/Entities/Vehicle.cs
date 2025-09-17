using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites
{
    public class Vehicle : BaseEntity
    {
        public Vehicle(string name, VehicleRegistrationPlateVO vehicleRegistrationPlate, VehicleType type, RodadoEnum rodado, CarroceriaEnum carroceria)
        {
            Name = name;
            VehicleRegistrationPlate = vehicleRegistrationPlate;
            Type = type;
            Rodado = rodado;
            Carroceria = carroceria;
        }
        public string Name { get; private set; }
        public VehicleRegistrationPlateVO VehicleRegistrationPlate { get; private set; }
        public VehicleType Type { get; private set; }
        public RodadoEnum Rodado { get; private set; }
        public CarroceriaEnum Carroceria { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        public void UpdateVehicle(string name, VehicleRegistrationPlateVO vehicleRegistrationPlate, VehicleType type, RodadoEnum rodado, CarroceriaEnum carroceria)
        {
            Name = name;
            VehicleRegistrationPlate = vehicleRegistrationPlate;
            Type = type;
            Rodado = rodado;
            Carroceria = carroceria;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
