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

        public CteRequest(Guid id, string name,string description, IFormFile file )
        {
            Id = id;
            Name = name;
            Description = description;
            File = file;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
