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
        public LoadVO(string product, float weight, LoadType loadType)
        {
            Product = product;
            Weight = weight;
            LoadType = loadType;
        }
        public string Product { get; set; }
        public float Weight { get; set; }
        public LoadType LoadType { get; set; }
    }
}
