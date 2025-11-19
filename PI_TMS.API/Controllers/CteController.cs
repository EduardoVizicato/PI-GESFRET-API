using Microsoft.AspNetCore.Mvc;
//using TMS.Domain.Entities.Requests.;
using TMS.Domain.Entities.Requests.Cte;

namespace PI_TMS.API.Controllers
{
    [Route("api/Cte")]
    [ApiController]
    public class CteController : ControllerBase 
    {
        
       
        //[HttpPost]
        //public IActionResult PostCte([FromForm] CteRequest cteRequest)
        //{
        //    var filePath = Path.Combine("Storage", cteRequest.File.FileName);
        //    //var cteData = new Cte(cteRequest.Name, cteRequest.Description, filePath);
        //    // Process the received CTe data (cteData)
        //    // For demonstration, we'll just return a success message
        //    return Ok(new { Message = "CTe data received successfully" });
        //}
    }
}
