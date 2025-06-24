using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.ValueObjects;
using TMS.Domain.Entites;
using TMS.Domain.Entities;

namespace TMS.Domain.Entites.Responses.Load
{
    public class LoadResponse
    {
        public DescriptionVO Description { get; set; }
        public float Quantity { get; set; }
        public TypeVO Type { get; set; }
        public Guid UserId { get; set; }
    }
}
