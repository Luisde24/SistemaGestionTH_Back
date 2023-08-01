using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Area.Querys
{
    public class GetAreaByIdQuery : IRequest<Areas>
    {
        public long Id { get; set; }
        public GetAreaByIdQuery(long id)
        {
            Id = id;
        }
    }
}
