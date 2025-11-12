using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entites;
using TMS.Domain.Entites.Requests.Travel;
using TMS.Domain.Entites.Responses.Travel;
using TMS.Domain.Entities.Common.Criteria;
using TMS.Domain.Entities.Responses.Vehicle;
using TMS.Domain.Repositories;
using TMS.Infrastructure.Data;

namespace TMS.Infrastructure.Repositories;

public class TravelRepository : ITravelRepository
{
    private readonly ApplicationDataContext _context;
    public TravelRepository(ApplicationDataContext context)
    {
        _context = context;
    }

    // Mantém método existente retornando entidades
    public async Task<List<Travel>> GetAllAsync(TravelCriteria criteria)
    {
        IQueryable<Travel> query = _context.Travels.AsQueryable();

        if (criteria != null)
        {
            if (criteria.IsCancelled.HasValue)
                query = query.Where(t => t.IsCanceled == criteria.IsCancelled.Value);

            if (criteria.StartDate.HasValue)
                query = query.Where(t => t.StartDate >= criteria.StartDate.Value);

            if (criteria.EndDate.HasValue)
                query = query.Where(t => t.EndDate <= criteria.EndDate.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Travel> GetByIdAsync(Guid id)
    {
        return await _context.Travels.FindAsync(id);
    }

    // Novo: lista Travel + Vehicle já projetados em DTO
    public async Task<List<TravelResponse>> GetAllWithVehicleAsync(TravelCriteria? criteria = null)
    {
        var travels = _context.Travels.AsNoTracking();

        if (criteria != null)
        {
            if (criteria.IsCancelled.HasValue)
                travels = travels.Where(t => t.IsCanceled == criteria.IsCancelled.Value);

            if (criteria.StartDate.HasValue)
                travels = travels.Where(t => t.StartDate >= criteria.StartDate.Value);

            if (criteria.EndDate.HasValue)
                travels = travels.Where(t => t.EndDate <= criteria.EndDate.Value);
        }

        var query =
            from t in travels
            join v in _context.Vehicles.AsNoTracking() on t.VehicleId equals v.Id
            select new
            {
                Travel = new TravelResponse(
                    t.Id,
                    t.StartDate,
                    t.EndDate,
                    t.Origin,
                    t.Destination,
                    t.Load,
                    t.Price,
                    t.CreatedAt,
                    t.UpdatedAt,
                    t.IsCanceled
                ),
                Vehicle = new VehicleSummaryResponse
                {
                    Id = v.Id,
                    Name = v.Name,
                    RegistrationPlate = v.VehicleRegistrationPlate.RegistrationPlate,
                    TruckType = v.TruckType,
                    WheelType = v.WheelType,
                    BodyType = v.BodyType
                }
            };

        var data = await query.ToListAsync();

        // Anexa o veículo a cada TravelResponse
        foreach (var row in data)
            row.Travel.Vehicle = row.Vehicle;

        return data.Select(x => x.Travel).ToList();
    }

    // Novo: detalhe por Id já com Vehicle
    public async Task<TravelResponse?> GetByIdWithVehicleAsync(Guid id)
    {
        var result =
            await (from t in _context.Travels.AsNoTracking().Where(x => x.Id == id)
                   join v in _context.Vehicles.AsNoTracking() on t.VehicleId equals v.Id
                   select new
                   {
                       Travel = new TravelResponse(
                           t.Id,
                           t.StartDate,
                           t.EndDate,
                           t.Origin,
                           t.Destination,
                           t.Load,
                           t.Price,
                           t.CreatedAt,
                           t.UpdatedAt,
                           t.IsCanceled
                       ),
                       Vehicle = new VehicleSummaryResponse
                       {
                           Id = v.Id,
                           Name = v.Name,
                           RegistrationPlate = v.VehicleRegistrationPlate.RegistrationPlate,
                           TruckType = v.TruckType,
                           WheelType = v.WheelType,
                           BodyType = v.BodyType
                       }
                   })
                  .FirstOrDefaultAsync();

        if (result == null) return null;

        result.Travel.Vehicle = result.Vehicle;
        return result.Travel;
    }

    // Criação já recebe somente VehicleId no request (como você tem)
    public async Task<TravelRequest> AddAsync(TravelRequest travel)
    {
        var addTravel = new Travel(
            travel.StartDate,
            travel.EndDate,
            travel.Origin,
            travel.Destination,
            travel.Price,
            travel.Load,
            travel.VehicleId
        );

        _context.Travels.Add(addTravel);
        await _context.SaveChangesAsync();
        return travel;
    }

    // Opcional: criar e já retornar o DTO detalhado (Travel + Vehicle)
    public async Task<TravelResponse?> AddAndReturnAsync(TravelRequest travel)
    {
        var addTravel = new Travel(
            travel.StartDate,
            travel.EndDate,
            travel.Origin,
            travel.Destination,
            travel.Price,
            travel.Load,
            travel.VehicleId
        );

        _context.Travels.Add(addTravel);
        await _context.SaveChangesAsync();

        return await GetByIdWithVehicleAsync(addTravel.Id);
    }

    public async Task<bool?> UpdatesAsync(Guid id, TravelResponse travel)
    {
        var updateTravel = await _context.Travels.FindAsync(id);
        if (updateTravel == null) return false;

        updateTravel.UpdateTravel(travel.StartDate, travel.EndDate, travel.Origin, travel.Destination, travel.Price, travel.Load);
        _context.Travels.Update(updateTravel);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> CancelTravel(Guid id)
    {
        var cancelTravel = await _context.Travels.FindAsync(id);
        if (cancelTravel == null) return false;

        cancelTravel.CancelTravel();
        _context.Travels.Update(cancelTravel);
        return await _context.SaveChangesAsync() > 0;
    }
}