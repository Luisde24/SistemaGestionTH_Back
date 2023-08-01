using MediatR;
using SistemaGestionTH.Application.ManagementOverTime.Commands;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.ManagementOverTime.Handlers
{
    public class CreatedOverTimeCommandHandler : IRequestHandler<CreateManagementOfOverTimeCommand, ManagementOfOverTime>
    {
        private readonly IManagementOfOverTimeRepository _managementRepository;
        public CreatedOverTimeCommandHandler(IManagementOfOverTimeRepository managementRepository)
        {
            _managementRepository = managementRepository;
        }

        public async Task<ManagementOfOverTime> Handle(CreateManagementOfOverTimeCommand request, CancellationToken cancellationToken)
        {
            var management = new ManagementOfOverTime(request.Id, request.Reason.ToLower(), request.AdditionalTime, request.DateOfRequest, request.Leader, request.State, request.TypeRemuneration);

            if(management == null)
                throw new ApplicationException($"Error al crear la entidad");

            management.EmployeesId = request.EmployeesId;
            management.AreaId = request.AreaId;
            
            return await _managementRepository.CreatedManagementOfOverTimeAsync(management);

        }
    }
}
