using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employees>>
    {
    }
}
