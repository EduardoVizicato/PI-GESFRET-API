using Microsoft.AspNetCore.Mvc;
using TMS.Application.Services.Interfaces;
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
        public async Task<IActionResult> GetAll()
        {
            var data = await _travelService.GetAllAsync();
            if (data == null)
                return BadRequest();

            return Ok(data);
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
        
        [HttpPost("changeTravelStatus")]
        public async Task<IActionResult> ChangeTravelStatus(Guid id)
        {
            var data = await _travelService.ChangeStatusAsync(id);
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