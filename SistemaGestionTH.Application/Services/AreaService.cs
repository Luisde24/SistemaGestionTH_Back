using AutoMapper;
using MediatR;
using SistemaGestionTH.Application.Area.Commands;
using SistemaGestionTH.Application.Area.Querys;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreasRepository _areaRepositorio;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AreaService(IAreasRepository areaRepositorio, IMapper mapper, IMediator mediator)
        {
            _areaRepositorio = areaRepositorio;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreatedAreaAsync(AreasDto areasDto)
        {
            var areaCreateCommand = _mapper.Map<CreateAreaCommand>(areasDto);
            await _mediator.Send(areaCreateCommand);
        }

        public async Task DeleteAreaAsync(long? id)
        {
            var areaRemoveCommand = new DeleteAreaCommand(id.Value);
            if(areaRemoveCommand == null)
                throw new Exception($"Error al cargar entidad");

            await _mediator.Send(areaRemoveCommand);
        }

        public async Task UpdateAreaAsync(AreasDto areasDto)
        {
            var areaUpdateCommand = _mapper.Map<UpdateAreaCommand>(areasDto);
            await _mediator.Send(areaUpdateCommand);
        }

        public async Task<IEnumerable<AreasDto>> GetListAreasAsync()
        {
            var areaQuery = new GetAreasQuerys();
            if(areaQuery == null)
                throw new Exception($"Error al cargar entidad");
            var result = await _mediator.Send(areaQuery);

            return _mapper.Map<IEnumerable<AreasDto>>(result);
        }

        public async Task<AreasDto> GetAreaByIdAsync(long? id)
        {
            var areaQueryById = new GetAreaByIdQuery(id.Value);
            
            if (areaQueryById == null)
                throw new Exception($"Error al cargar entidad");
            
            var result = await _mediator.Send(areaQueryById);

            return _mapper.Map<AreasDto>(result);
        }

    }
}
