using MediatR;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.ManagementOverTime.Commands
{
    public abstract class ManagementOfOverTimeCommand : IRequest<ManagementOfOverTime>
    {
        public string Reason { get; private set; }
        public int AdditionalTime { get; private set; }
        public DateTime DateOfRequest { get; private set; }
        public string Leader { get; private set; }
        public StateEnum State { get; set; }
        public TypeRemunerationEnum TypeRemuneration { get; set; }
        public long EmployeesId { get; set; }
        public long AreaId { get; set; }
    }
}
