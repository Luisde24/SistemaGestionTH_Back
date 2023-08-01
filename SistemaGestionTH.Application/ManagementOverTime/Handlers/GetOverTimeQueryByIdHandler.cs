using MediatR;
using SistemaGestionTH.Application.Area.Querys;
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
    public class GetOverTimeQueryByIdHandler : IRequestHandler<GetOverTimeByIdQuery, ManagementOfOverTime>
    {
        private readonly IManagementOfOverTimeRepository _maangementRepository;
        public GetOverTimeQueryByIdHandler(IManagementOfOverTimeRepository maangementRepository)
        {
            _maangementRepository = maangementRepository;
        }

        public async Task<ManagementOfOverTime> Handle(GetOverTimeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _maangementRepository.GetManagementOfOverTimeByIdAsync(request.Id);
        }
    }
}
