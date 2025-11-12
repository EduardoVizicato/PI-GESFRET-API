using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;
using static NuGet.Packaging.PackagingConstants;

namespace TMS.Domain.Entites
{
    public class Vehicle : BaseEntity
    {
        private readonly List<Travel> _travels = new();
        
        public IReadOnlyCollection<Travel> Travels => _travels.AsReadOnly();

        private Vehicle() { }
        public Vehicle(string name, VehicleRegistrationPlateVO vehicleRegistrationPlate, VehicleType truckType, RodadoEnum wheelType, CarroceriaEnum bodyType)
        {
            Name = name;
            VehicleRegistrationPlate = vehicleRegistrationPlate;
            TruckType = truckType;
            WheelType = wheelType;
            BodyType = bodyType;
        }
        public string Name { get; private set; }
        public VehicleRegistrationPlateVO VehicleRegistrationPlate { get; private set; }
        public VehicleType TruckType { get; private set; }
        public RodadoEnum WheelType { get; private set; }
        public CarroceriaEnum BodyType { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        

        public void UpdateVehicle(string name, VehicleRegistrationPlateVO vehicleRegistrationPlate, VehicleType truckType, RodadoEnum wheelType, CarroceriaEnum bodyType)
        {
            Name = name;
            VehicleRegistrationPlate = vehicleRegistrationPlate;
            TruckType = truckType;
            WheelType = wheelType;
            BodyType = bodyType;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
