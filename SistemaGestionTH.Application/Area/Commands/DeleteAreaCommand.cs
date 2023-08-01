using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Commands
{
    public class DeleteAreaCommand : IRequest<Areas>
    {
        public long Id { get; set; }
        public DeleteAreaCommand(long id)
        {

            Id = id;
        }
    }
}
