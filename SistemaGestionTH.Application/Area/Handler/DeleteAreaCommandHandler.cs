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
    public class DeleteAreaCommandHandler : IRequestHandler<DeleteAreaCommand, Areas>
    {
        private readonly IAreasRepository _areaRepository;
        public DeleteAreaCommandHandler(IAreasRepository areaRepository)
        {
            _areaRepository= areaRepository;    
        }

        public async Task<Areas> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            var area = await _areaRepository.GetAreaByIdAsync(request.Id);

            if(area == null)
                throw new ApplicationException($"No existe area con identificado " + request.Id);
            
            return await _areaRepository.DeleteAreaAsync(area);
        }
    }
}
