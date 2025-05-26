using Microsoft.AspNetCore.Mvc;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites.Requests.Load;

namespace PI_TMS.API.Controllers
{

    [Route("api/load")]
    [ApiController]
    public class LoadController : Controller
    {
        private readonly ILoadService _loadService;
        public LoadController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpGet("getAllLoads")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _loadService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("addLoad")]
        public async Task<IActionResult> AddLoad(LoadRequest load)
        {
            var data = await _loadService.AddAsync(load);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        
        [HttpGet("getLoadById")]
        public async Task<IActionResult> GetLoadById(Guid id)
        {
            var data = await _loadService.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        
        [HttpDelete("desactiveLoad")]
        public async Task<IActionResult> DesactiveLoad(Guid id)
        {
            var data = await _loadService.DesactiveAsync(id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        
        [HttpGet("getAllActivedLoads")]
        public async Task<IActionResult> GetAllActivedLoads()
        {
            var data = await _loadService.GetAllActived();
            if (data == null)
            {
                return BadRequest();
            }

            return Ok(data);
        }
        
        [HttpGet("getAllDesactivedLoads")]
        public async Task<IActionResult> GetAllDesactivedLoads()
        {
            var data = await _loadService.GetAllDesactived();
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}