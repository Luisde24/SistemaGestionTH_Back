using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Commands
{
    public abstract class AreaCommand : IRequest<Areas>
    {
        public string Name { get; set; }
    }
}
