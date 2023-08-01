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
    public class DeleteOverTimeCommandHandler : IRequestHandler<DeleteManagementOfOverTimeCommand, ManagementOfOverTime>
    {
        private readonly IManagementOfOverTimeRepository _managemenRepository;
        public DeleteOverTimeCommandHandler(IManagementOfOverTimeRepository managemenRepository)
        {
            _managemenRepository = managemenRepository;
        }

        public async Task<ManagementOfOverTime> Handle(DeleteManagementOfOverTimeCommand request, CancellationToken cancellationToken)
        {
            var management = await _managemenRepository.GetManagementOfOverTimeByIdAsync(request.Id);

            if (management == null)
                throw new ApplicationException($"No existe resgistro con identificado " + request.Id);


            return await _managemenRepository.DeleteManagementOfOverTimeAsync(management);
        }
    }
}
