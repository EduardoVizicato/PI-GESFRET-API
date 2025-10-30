using System.Diagnostics;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;
using TMS.Domain.Repositories;
using TMS.Infrastructure.Repositories;

namespace TMS.Application.Services.Implementation
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        public EnterpriseService(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<Enterprise> GetEnterpriseByIdAsync(Guid id)
        {
            var EnterpriseById = await _enterpriseRepository.GetByIdAsync(id);
            if (EnterpriseById == null)
                return null;

            return EnterpriseById;
        }
        public async Task<EnterpriseRequest> AddEnterpriseAsync(EnterpriseRequest enterprise)
        {
            var addEnterprise = await _enterpriseRepository.AddAsync(enterprise);

            return addEnterprise;
        }

        public async Task<bool> UpdateEnterpriseAsync(Guid id, EnterpriseResponse enterprise)
        {
            var checkId = await _enterpriseRepository.GetByIdAsync(id);
            if (checkId == null)
                return false;

            var updateTravel = await _enterpriseRepository.UpdatesAsync(id, enterprise);
            return updateTravel;
        }

        public Task<bool?> DesactiveEnterpriseeAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
