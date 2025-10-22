using Microsoft.AspNetCore.Http.HttpResults;
using TMS.Application.Models;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites;
using TMS.Domain.Entites.Requests.Travel;
using TMS.Domain.Entites.Responses.Travel;
using TMS.Domain.Entities.Common.Criteria;
using TMS.Domain.Repositories;

namespace TMS.Application.Services.Implementation;

public class TravelService : ITravelService
{
    private readonly  ITravelRepository _travelRepository;
    public TravelService(ITravelRepository travelRepository)
    {
        _travelRepository = travelRepository;   
    }

    public async Task<List<Travel>> GetAllAsync(TravelResultFilter filter)
    {
        if (filter?.StartDate.HasValue == true && filter?.EndDate.HasValue == true && filter?.StartDate > filter?.EndDate)
        {
            throw new ArgumentException("The Start Date needs to be less than the End Date");
        }

        var criteria = new TravelCriteria
        {
            IsCancelled = filter?.IsCancelled,
            StartDate = filter?.StartDate,
            EndDate = filter?.EndDate
        };

        return await _travelRepository.GetAllAsync(criteria);
    }

    public async Task<Travel> GetByIdAsync(Guid id)
    {
        var travelById = await _travelRepository.GetByIdAsync(id);
        if(travelById == null)
            return null;
        
        return travelById;
    }

    public async Task<TravelRequest> AddAsync(TravelRequest travel)
    {
       var addTravel = await _travelRepository.AddAsync(travel);
       
        return addTravel;
    }

    public async Task<bool?> UpdatesAsync(Guid id, TravelResponse travel)
    {
        var checkId = await _travelRepository.GetByIdAsync(id);
        if(checkId == null)
            return false;
        
        var updateTravel = await _travelRepository.UpdatesAsync(id, travel);
        return updateTravel;
    }

    public async Task<bool> CancelTravel(Guid id)
    {
        var cancelTravel = await _travelRepository.CancelTravel(id);
        return cancelTravel;
    }
}