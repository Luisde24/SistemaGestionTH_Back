using MediatR;
using SistemaGestionTH.Application.Area.Commands;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Handler
{
    public class CreatedAreaCommandHandler : IRequestHandler<CreateAreaCommand, Areas>
    {
        private readonly IAreasRepository _areaRepository;
        public CreatedAreaCommandHandler(IAreasRepository areaRepository)
        {
            _areaRepository= areaRepository;
        }

        public async Task<Areas> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            var area = new Areas(request.Name.ToLower());

            if(area == null)
                throw new ApplicationException($"Error al crear la entidad");

            return await _areaRepository.CreatedAreaAsync(area);
        }
    }
}
