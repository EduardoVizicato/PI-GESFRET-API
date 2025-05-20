﻿using TMS.Domain.Entites;
using TMS.Domain.Entites.Requests.Vehicle;
using TMS.Domain.Entites.Responses.Vehicle;
using TMS.Domain.Entities;

namespace TMS.Domain.Repositories;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAllVehiclesAsync();
    Task<Vehicle> GetVehicleByIdAsync(Guid id);
    Task<VehicleRequest> AddVehicleAsync(VehicleRequest vehicle);
    Task<bool?> UpdateVehicleAsync(Guid id,VehicleResponse vehicle);
    Task<bool?> DesactiveVehicleAsync(Guid id);
    Task<List<Vehicle>> GetAllDesactivedVehicles();
    Task<List<Vehicle>> GetAllDesactivedVehciles();
}