using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Requests.Cte;
using TMS.Domain.Entities.Requests.Enterprise;
using TMS.Domain.Repositories;
using TMS.Infrastructure.Repositories;

namespace TMS.Application.Services.Implementation
{
    public class CteService : ICteService
    {
        private readonly ICteRepository _cteRepository;
        public CteService(ICteRepository cteRepository)
        {
            _cteRepository = cteRepository;
        }
        public async Task AddCteAsync(CteRequest cteRequest)
        {
            var entity = new Cte(cteRequest.Name, cteRequest.Description, cteRequest.File)
            { };

            await _cteRepository.AddAsync(entity);

        }

        
            
        }
    }
