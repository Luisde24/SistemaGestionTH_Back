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
    public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, Areas>
    {
        private readonly IAreasRepository _areaRepository;
        public UpdateAreaCommandHandler(IAreasRepository areaRepository)
        {
            _areaRepository= areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
        }

        public async Task<Areas> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            var area = await _areaRepository.GetAreaByIdAsync(request.Id);

            if(area == null)
                throw new ApplicationException($"El area no registra en la base de datos.");

            area.UpdateAreas(request.Name.ToLower());
            return await _areaRepository.UpdateAreaAsync(area);
        }
    }
}
