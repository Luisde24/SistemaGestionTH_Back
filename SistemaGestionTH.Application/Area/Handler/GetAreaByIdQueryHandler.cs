using MediatR;
using SistemaGestionTH.Application.Area.Querys;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Handler
{
    public class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery, Areas>
    {
        private readonly IAreasRepository _areaRepository;
        public GetAreaByIdQueryHandler(IAreasRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<Areas> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _areaRepository.GetAreaByIdAsync(request.Id);
        }
    }
}
