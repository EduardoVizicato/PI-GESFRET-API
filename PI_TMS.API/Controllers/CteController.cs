using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddCte([FromForm] CteRequest cteRequest)
        {
            var filePath = Path.Combine("Storage", cteRequest.File.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                cteRequest.File.CopyTo(fileStream);
            }

            var data = await _service.AddCteAsync(cteRequest);

            return Ok();
        }
    }
}
