using System;
using System.Threading.Tasks;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;
using TMS.Domain.Repositories;

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
        public async Task<Guid> AddEnterpriseAsync(EnterpriseRequest enterprise)
        {
            var entity = new Enterprise(enterprise.Name, enterprise.Email, enterprise.TaxId)
            {
            };

            await _enterpriseRepository.AddAsync(entity);

            return entity.Id;
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
