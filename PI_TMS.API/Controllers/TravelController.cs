using Microsoft.AspNetCore.Mvc;
using PI_TMS.API.Models.ViewModel;
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

            var travels = await _travelService.GetAllAsync(filter).ConfigureAwait(false);
            return Ok(travels ?? new());
        }

        [HttpPost("addTravel")]
        public async Task<IActionResult> AddTravel([FromForm] TravelViewModel travelView)
        {
            var randomName = Guid.NewGuid().ToString();
            var filePath = Path.Combine("Storage", randomName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            travelView.File.CopyTo(fileStream);

            var travel = new TravelRequest(
                travelView.StartDate,
                travelView.EndDate,
                travelView.Origin,
                travelView.Destination,
                travelView.Load,
                travelView.Price,
                travelView.TruckId,
                travelView.EnterpriseId,
                filePath
            );

            var data = await _travelService.AddAsync(travel);
            if (data == null)
                return BadRequest();
            
            return Ok(data);
        }
        [HttpPost("download")]
        public async Task<IActionResult> Download(Guid id)
        {
            var data = await _travelService.GetByIdAsync(id);
            
            if (data == null)
                return BadRequest();

            var dataBytes = System.IO.File.ReadAllBytes(data.FilePath);

            return File(dataBytes, "application/pdf");
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