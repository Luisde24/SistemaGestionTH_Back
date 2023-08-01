using AutoMapper;
using MediatR;
using SistemaGestionTH.Application.Area.Querys;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Application.ManagementOverTime.Commands;
using SistemaGestionTH.Application.ManagementOverTime.Querys;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Services
{
    public class ManagementOfOverTimeService : IManagementOfOverTimeService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ManagementOfOverTimeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task CreatedManagementOfOverTimeAsync(ManagementOfOverTimeDto overTime)
        {
            var managementCommand = _mapper.Map<CreateManagementOfOverTimeCommand>(overTime);
            await _mediator.Send(managementCommand);
        }

        public async Task DeleteManagementOfOverTimeAsync(long? id)
        {
            var managemenCommand = new DeleteManagementOfOverTimeCommand(id.Value);

            if(managemenCommand == null)
                throw new Exception($"Error al cargar entidad");

              await _mediator.Send(managemenCommand);
        }

        public async Task UpdateManagementOfOverTimeAsync(ManagementOfOverTimeDto overTime)
        {
            var managementCommand = _mapper.Map<UpdateManagementOfOverTimeCommand>(overTime);

            if (managementCommand == null)
                throw new Exception($"Error al cargar entidad");

            await _mediator.Send(managementCommand);
        }

        public async Task<IEnumerable<ManagementOfOverTimeDto>> GetListManagementOfOverTimesAsync()
        {
            var managementQuery = new GetOverTimeQuerys();
            if (managementQuery == null)
                throw new Exception($"Error al cargar entidad");

            var result = await _mediator.Send(managementQuery);

            return _mapper.Map<IEnumerable<ManagementOfOverTimeDto>>(result);
        }

        public async Task<ManagementOfOverTimeDto> GetManagementOfOverTimeByIdAsync(long? id)
        {
            var managementQueryById = new GetOverTimeByIdQuery(id.Value);
           
            if (managementQueryById == null)
                throw new Exception($"Error al cargar entidad");

            var result = await _mediator.Send(managementQueryById);

            return _mapper.Map<ManagementOfOverTimeDto>(result);

        }

        
    }
}
