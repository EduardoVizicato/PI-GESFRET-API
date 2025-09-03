using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Common.Enums;

namespace TMS.Domain.ValueObjects
{
    public class LoadVO
    {
        public LoadVO(string name, float weight, LoadType loadType)
        {
            Name = name;
            Weight = weight;
            LoadType = loadType;
        }
        public string Name { get; set; }
        public float Weight { get; set; }
        public LoadType LoadType { get; set; }
    }
}
