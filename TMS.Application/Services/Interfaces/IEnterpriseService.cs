
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;

namespace TMS.Application.Services.Interfaces
{
    public interface IEnterpriseService
    {
        Task<Enterprise> GetEnterpriseByIdAsync(Guid id);
        Task<Guid> AddEnterpriseAsync(EnterpriseRequest enterprise);
        Task<bool> UpdateEnterpriseAsync(Guid id, EnterpriseResponse enterprise);
        Task<bool?> DesactiveEnterpriseeAsync(Guid id);
    }
}
