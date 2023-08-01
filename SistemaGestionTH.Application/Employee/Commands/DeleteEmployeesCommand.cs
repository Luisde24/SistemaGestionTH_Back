using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Commands
{
    public class DeleteEmployeesCommand : IRequest<Employees>
    {
        public long Id { get; set; }
        public DeleteEmployeesCommand(long id)
        {
            Id = id;
        }
    }
}
