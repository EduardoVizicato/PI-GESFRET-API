using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities.Requests.Cte
{
    public class CteRequest
    {
        public CteRequest(string name,string description, IFormFile file )
        {
            Name = name;
            Description = description;
            File = file;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
