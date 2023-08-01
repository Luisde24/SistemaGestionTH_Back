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
    public class UpdateOverTimeCommandHandler : IRequestHandler<UpdateManagementOfOverTimeCommand, ManagementOfOverTime>
    {
        private readonly IManagementOfOverTimeRepository _managementRepository;
        public UpdateOverTimeCommandHandler(IManagementOfOverTimeRepository managementRepository)
        {
            _managementRepository= managementRepository ?? throw new ArgumentNullException(nameof(managementRepository));
        }

        public async Task<ManagementOfOverTime> Handle(UpdateManagementOfOverTimeCommand request, CancellationToken cancellationToken)
        {
            var management = await _managementRepository.GetManagementOfOverTimeByIdAsync(request.Id);

            if(management == null)
                throw new ApplicationException($"El registro no existe en la base de datos.");

            management.UpdateManejoHorasExtras(request.Reason, request.AdditionalTime, request.DateOfRequest, request.Leader, request.State, request.TypeRemuneration, request.EmployeesId, request.AreaId);

            return await _managementRepository.UpdateManagementOfOverTimeAsync(management);

        }
    }
}
