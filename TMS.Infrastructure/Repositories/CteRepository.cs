using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Cte;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Repositories;
using TMS.Infrastructure.Data;

namespace TMS.Infrastructure.Repositories
{
    public class CteRepository : ICteRepository
    {
        private readonly ApplicationDataContext _context;

        public CteRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<CteRequest> AddAsync(Cte cte)
        {
            var addCte = new CteRequest(
                cte.Name,
                cte.Description,
                cte.File
                );
            _context.Ctes.Add(cte);
            await _context.SaveChangesAsync();
            return addCte;
        }
    }
}
