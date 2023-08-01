using MediatR;
using SistemaGestionTH.Application.ManagementOverTime.Querys;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.ManagementOverTime.Handlers
{
    public class GetOverTimeQuerysHandler : IRequestHandler<GetOverTimeQuerys, IEnumerable<ManagementOfOverTime>>
    {
        private readonly IManagementOfOverTimeRepository _managementRepository;
        public GetOverTimeQuerysHandler(IManagementOfOverTimeRepository managementRepository)
        {
            _managementRepository = managementRepository;
        }

        public async Task<IEnumerable<ManagementOfOverTime>> Handle(GetOverTimeQuerys request, CancellationToken cancellationToken)
        {
            return await _managementRepository.GetListManagementOfOverTimesAsync();
        }
    }
}
