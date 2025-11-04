using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Entities.Responses.Enterprise;
using TMS.Domain.Repositories;
using TMS.Infrastructure.Data;

namespace TMS.Infrastructure.Repositories
{
    internal class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly ApplicationDataContext _context;

        public EnterpriseRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<Enterprise> GetByIdAsync(Guid id)
        {
            return await _context.Enterprises.FindAsync(id);
        }

        public async Task<EnterpriseRequest> AddAsync(Enterprise enterprise)
        {
            var addEnterprise = new EnterpriseRequest(
                enterprise.Name,
                enterprise.Email,
                enterprise.TaxId
                );
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();
            return addEnterprise;
        }


        public async Task<bool> UpdatesAsync(Guid id, EnterpriseResponse enterprise)
        {
            var updateEnterprise = await _context.Enterprises.FindAsync(id);
            updateEnterprise.UpdateEnterprise(enterprise.Name,enterprise.Email,enterprise.TaxId
                );
            _context.Enterprises.Update(updateEnterprise);
            return await _context.SaveChangesAsync() > 0;
        }
        public Task<bool?> DesactiveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
