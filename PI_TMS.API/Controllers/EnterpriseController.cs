using Microsoft.AspNetCore.Mvc;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;

namespace PI_TMS.API.Controllers
{
    [Route("api/Enterprise")]
    [ApiController]

    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseService _service;
        public EnterpriseController(IEnterpriseService service)
        {
            _service = service;
        }

        [HttpGet("getEnterpriseById")]
        public async Task<IActionResult> GetEnterpriseById(Guid id)
        {
            var data = await _service.GetEnterpriseByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("addEnterprise")]
        public async Task<IActionResult> AddEnterprise(EnterpriseRequest enterprise)
        {
            var data = await _service.AddEnterpriseAsync(enterprise);
            return Ok();
        }
        [HttpPut("updateEnterprise")]
        public async Task<IActionResult> UpdateEnterprise(Guid id, EnterpriseResponse enterprise)
        {
            var data = await _service.UpdateEnterpriseAsync(id, enterprise);
            return Ok();
        }
        
    }
}
