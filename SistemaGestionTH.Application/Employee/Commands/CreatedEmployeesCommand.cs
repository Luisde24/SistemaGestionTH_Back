using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Commands
{
    public class CreatedEmployeesCommand : EmployeesCommand
    {
        public long Id { get; set; }
    }
}
