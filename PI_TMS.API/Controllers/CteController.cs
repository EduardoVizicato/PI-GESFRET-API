using Microsoft.AspNetCore.Mvc;
using TMS.Domain.Entities.Requests.;
using TMS.Domain.Entities.Requests.Cte;

namespace PI_TMS.API.Controllers
{
    [Route("api/Cte")]
    [ApiController]
    public class CteController : ControllerBase 
    {
        [HttpPost]
        public IActionResult PostCte([FromForm] CteRequest cteRequest)
        {
            var filePath = Path.Combine("Storage", cteRequest.File.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            cteRequest.File.CopyTo(fileStream);

            //var cteData = new Cte(cteRequest.Name, cteRequest.Description, filePath);


            return Ok(new { Message = "CTe data received successfully" });
        }
    }
}
