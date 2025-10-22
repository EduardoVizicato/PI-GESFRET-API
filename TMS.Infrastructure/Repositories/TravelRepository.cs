using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entites;
using TMS.Domain.Entites.Requests.Travel;
using TMS.Domain.Entites.Responses.Travel;
using TMS.Domain.Entities.Common.Criteria;
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
    public async Task<List<Travel>> GetAllAsync(TravelCriteria criteria)
    {
        IQueryable<Travel> query = _context.Travels.AsQueryable();

        if (criteria != null)
        {
            if (criteria.IsCancelled.HasValue)
            {
                query = query.Where(t => t.IsCanceled == criteria.IsCancelled.Value);
            }

            if (criteria.StartDate.HasValue)
            {
                query = query.Where(t => t.StartDate >= criteria.StartDate.Value);
            }

            if (criteria.EndDate.HasValue)
            {
                query = query.Where(t => t.EndDate <= criteria.EndDate.Value);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<Travel> GetByIdAsync(Guid id)
    {
        return await _context.Travels.FindAsync(id);
    }

    public async Task<TravelRequest> AddAsync(TravelRequest travel)
    {
        var addTravel = new Travel(
            travel.StartDate,
            travel.EndDate,
            travel.Origin,
            travel.Destination,
            travel.Price,
            travel.Load
            );
        _context.Travels.Add(addTravel);
        await _context.SaveChangesAsync();
        return travel;
    }

    public async Task<bool?> UpdatesAsync(Guid id, TravelResponse travel)
    {
        var updateTravel = await _context.Travels.FindAsync(id);
        updateTravel.UpdateTravel(travel.StartDate,travel.EndDate,travel.Origin,travel.Destination,travel.Price,travel.Load);
        _context.Travels.Update(updateTravel);
        return await _context.SaveChangesAsync() > 0;
    }


    public async Task<bool> CancelTravel(Guid id)
    {
        var cancelTravel = await _context.Travels.FindAsync(id);

        if( cancelTravel == null)
            return false;

        cancelTravel.CancelTravel();
        _context.Travels.Update(cancelTravel);
        return await _context.SaveChangesAsync() > 0;
    }
}