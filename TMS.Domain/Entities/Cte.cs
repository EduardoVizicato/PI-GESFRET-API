using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entites;

namespace TMS.Domain.Entities
{
    public class Cte : BaseEntity
    {
        public Cte(string name, string description,string file)
        {
            Name = name;
            Description = description;
            File = file;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void UpdateCte(string name, string description, string file)
        {
            Name = name;
            Description = description;
            File = file;
            UpdatedAt = DateTime.Now;
        }

    }
}
