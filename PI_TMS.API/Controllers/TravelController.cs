using Microsoft.AspNetCore.Mvc;
using PI_TMS.API.Models.ViewModel;
using TMS.Application.Models;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites.Requests.Travel;
using TMS.Domain.Entites.Responses.Travel;
using System.IO
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll([FromQuery] TravelResultFilter? filter)
        {
            var travels = await _travelService.GetAllAsync(filter).ConfigureAwait(false);
            return Ok(travels ?? new());
        }

        [HttpPost("addTravel")]
        public async Task<IActionResult> AddTravel([FromForm] TravelViewModel travelView)
        {
            string? filePath = null;

            if (travelView.File != null && travelView.File.Length > 0)
            {
                var randomName = Guid.NewGuid().ToString() + Path.GetExtension(travelView.File.FileName);

                var storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
                if (!Directory.Exists(storagePath))
                {
                    Directory.CreateDirectory(storagePath);
                }

                filePath = Path.Combine(storagePath, randomName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await travelView.File.CopyToAsync(fileStream);
                }
            }

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

            if (data == null || string.IsNullOrEmpty(data.FilePath) || !System.IO.File.Exists(data.FilePath))
                return NotFound("Viagem ou arquivo associado não encontrado.");

            var dataBytes = await System.IO.File.ReadAllBytesAsync(data.FilePath);

            var contentType = "application/octet-stream";
            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(data.FilePath, out var foundContentType))
            {
                contentType = foundContentType;
            }

            return File(dataBytes, contentType, Path.GetFileName(data.FilePath));
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