using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entites;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;

namespace TMS.Domain.Repositories
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> GetEnterpriseByIdAsync(Guid id);
        Task<EnterpriseRequest> AddEnterpriseAsync(EnterpriseRequest enterprise);
        Task<bool> UpdateEnterpriseAsync(Guid id, EnterpriseResponse enterprise);
        Task<bool?> DesactiveEnterpriseeAsync(Guid id);
    }
}
