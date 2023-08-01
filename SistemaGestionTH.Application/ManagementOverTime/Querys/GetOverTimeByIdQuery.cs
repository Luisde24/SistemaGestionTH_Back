using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.ManagementOverTime.Querys
{
    public class GetOverTimeByIdQuery : IRequest<ManagementOfOverTime>
    {
        public long Id { get; set; }
        public GetOverTimeByIdQuery(long id)
        {
            Id = id;
        }
    }
}
