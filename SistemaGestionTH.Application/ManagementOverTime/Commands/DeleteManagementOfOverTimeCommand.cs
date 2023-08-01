using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.ManagementOverTime.Commands
{
    public class DeleteManagementOfOverTimeCommand : IRequest<ManagementOfOverTime>
    {
        public long Id { get; set; }    
        public DeleteManagementOfOverTimeCommand(long id)
        {
            Id = id;
        }
    }
}
