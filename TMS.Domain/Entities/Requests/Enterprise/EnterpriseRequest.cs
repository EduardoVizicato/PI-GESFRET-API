using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities.Requests.Enterprise
{
    public class EnterpriseRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }

    }
}
