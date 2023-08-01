using MediatR;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Commands
{
    public abstract class EmployeesCommand : IRequest<Employees>
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public TypeIdentificactionEnum TypeIdentification { get; private set; }
        public string Identification { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public long AreaId { get; set; }
    }
}
