using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.ValueObjects
{
    public class AdressVO
    {
        public AdressVO()
        {
            
        }
        public string City { get; set; }
        public string UF { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
    }
}
