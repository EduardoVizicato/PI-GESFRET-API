using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entites;

namespace TMS.Domain.Entities
{
    internal class Cte : BaseEntity
    {
        public Cte(string name, string description,IFormFile file)
        {
            Name = name;
            Description = description;
            File = file;
            IsActive = true;
            CreateAt = DateTime.Now;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public void UpdateCte(string name, string description, IFormFile file)
        {
            Name = name;
            Description = description;
            File = file;
            UpdateAt = DateTime.Now;
        }

    }
}
