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
        public EnterpriseRequest(Guid id, string name, string email, TaxIdVO taxId)
        {
            Id = id;
            Name = name;
            Email = email;
            TaxId = taxId;
        }

        public Guid Id { get;  set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public TaxIdVO TaxId { get; private set; }

    }
}
