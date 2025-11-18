using Microsoft.AspNetCore.Mvc;

namespace PI_TMS.API.Controllers
{
    [Route("api/Cte")]
    [ApiController]
    public class CteController : ControllerBase 
    {
        private readonly IWebHostEnvironment _env;

        public CteController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public HttpResponseMessage GetCte()
        {
            HttpResponseMessage result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            string pdfLocation = Path.Combine(_env.ContentRootPath, "Storage", "CTE-Sample.pdf");
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(pdfLocation));
            stream.Position = 0;
            if (stream != null)
            {
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
                {
                    FileName = "CTE-Sample.pdf"
                };
                result.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                result.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }
    }
}
