using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entities.Requests.Enterprise
{
    public class EnterpriseRequest
    {
        public EnterpriseRequest(string name, string email, TaxIdVO taxId)
        {
            Name = name;
            Email = email;
            TaxId = taxId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public TaxIdVO TaxId { get; private set; }

    }
}
