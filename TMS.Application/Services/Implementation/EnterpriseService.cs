using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;
using TMS.Application.Services.Interfaces;

namespace TMS.Application.Services.Implementation
{
    public class EnterpriseService : IEnterpriseService
    {
        public Task<EnterpriseRequest> AddEnterpriseAsync(EnterpriseRequest enterprise)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DesactiveEnterpriseeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Enterprise> GetEnterpriseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEnterpriseAsync(Guid id, EnterpriseResponse enterprise)
        {
            throw new NotImplementedException();
        }
    }
}
