using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Cte;
using TMS.Domain.Entities.Requests.Enterprise;

namespace TMS.Domain.Repositories
{
    public class ICteRepository
    {
        Task<CteRequest> AddAsync(Cte cte);
    }
}
