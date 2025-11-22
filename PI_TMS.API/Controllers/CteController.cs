using Microsoft.AspNetCore.Mvc;
using PI_TMS.API.Models.ViewModel;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Cte;

namespace PI_TMS.API.Controllers
{
    [Route("api/Cte")]
    [ApiController]
    public class CteController : ControllerBase 
    {
        private readonly ICteService _service;
        public CteController(ICteService service)
        {
            _service = service;
        }

        [HttpPost("addCte")]
        public async Task<IActionResult> AddCte([FromForm] CteViewModel cteViewModel)
        {

            var filePath = Path.Combine("Storage", cteViewModel.File.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            cteViewModel.File.CopyTo(fileStream);

            var cteRequest = new CteRequest(cteViewModel.Name, cteViewModel.Description, filePath);

            await _service.AddCteAsync(cteRequest);

            return Ok();
        }
        
    }
}
