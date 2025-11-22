using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities.Requests.Cte;

namespace TMS.Application.Services.Interfaces
{
    public interface ICteService
    {
        Task AddCteAsync(CteRequest cteRequest);
    }
}
