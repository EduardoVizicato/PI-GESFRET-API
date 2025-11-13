using TMS.Domain.Entites;
using TMS.Domain.Entities.Common.Enums;
using TMS.Domain.ValueObjects;

namespace PI_TMS.API.Models.ViewModel
{
    public class VehicleViewModel
    {
        public VehicleViewModel(Guid id, string name, VehicleRegistrationPlateVO vehicleRegistrationPlate, VehicleType truckType, RodadoEnum wheelType, CarroceriaEnum bodyType, DateTime? updatedAt, ICollection<TravelViewModel> travels)
        {
            Id = id;
            Name = name;
            VehicleRegistrationPlate = vehicleRegistrationPlate;
            TruckType = truckType;
            WheelType = wheelType;
            BodyType = bodyType;
            UpdatedAt = updatedAt;
            Travels = travels;
        }

        public Guid Id {  get; set; }
        public string Name { get;  set; }
        public VehicleRegistrationPlateVO VehicleRegistrationPlate { get;  set; }
        public VehicleType TruckType { get;  set; }
        public RodadoEnum WheelType { get;  set; }
        public CarroceriaEnum BodyType { get;  set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<TravelViewModel> Travels { get; set; }
    }
}
