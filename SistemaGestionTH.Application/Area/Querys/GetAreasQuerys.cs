using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Querys
{
    public class GetAreasQuerys : IRequest<IEnumerable<Areas>>
    {
    }
}
