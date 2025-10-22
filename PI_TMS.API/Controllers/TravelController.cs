using Microsoft.AspNetCore.Mvc;
using System.Windows.Markup;
using TMS.Application.Models;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites;
using TMS.Domain.Entites.Requests.Travel;
using TMS.Domain.Entites.Responses.Travel;

namespace PI_TMS.API.Controllers
{

    [Route("api/travel")]
    [ApiController]
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }


        [HttpGet("getAllTravels")]
        public async Task<IActionResult> GetAll([FromQuery]TravelResultFilter? filter)
        {
            if (filter?.StartDate.HasValue == true && filter?.EndDate.HasValue == true
            && filter.StartDate > filter.EndDate)
            {
                return BadRequest("StartDate must be less than or equal to EndDate.");
            }

            var travels = await _travelService.GetAllAsync(filter).ConfigureAwait(false);
            return Ok(travels ?? new());
        }

        [HttpPost("addTravel")]
        public async Task<IActionResult> AddTravel(TravelRequest travel)
        {
            var data = await _travelService.AddAsync(travel);
            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }
        
        [HttpGet("getTravelById")]
        public async Task<IActionResult> GetTravelById(Guid id)
        {
            var data = await _travelService.GetByIdAsync(id);
            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }

        [HttpPut("updateTravel")]
        public async Task<IActionResult> UpdateTravel(Guid id, TravelResponse travel)
        {
            var data = await _travelService.UpdatesAsync(id, travel);
            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }
        
        [HttpDelete("cancelTravel")]
        public async Task<IActionResult> CancelTravel(Guid id)
        {
            var data = await _travelService.CancelTravel(id);
            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }


    }
}