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
        Task<Enterprise> GetByIdAsync(Guid id);
        Task<EnterpriseRequest> AddAsync(Enterprise enterprise);
        Task<bool> UpdatesAsync(Guid id, EnterpriseResponse enterprise);
        Task<bool?> DesactiveAsync(Guid id);
    }
}
