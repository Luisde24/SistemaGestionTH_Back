using MediatR;
using SistemaGestionTH.Application.Area.Querys;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Handler
{
    public class GetAreasQuerysHandler : IRequestHandler<GetAreasQuerys, IEnumerable<Areas>>
    {
        private readonly IAreasRepository _areaRepository;
        public GetAreasQuerysHandler(IAreasRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<Areas>> Handle(GetAreasQuerys request, CancellationToken cancellationToken)
        {
            return await _areaRepository.GetListAreasAsync();
        }
    }
}
