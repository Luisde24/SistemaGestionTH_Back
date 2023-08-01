using MediatR;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employees>
    {
        public long Id { get; set; }
        public GetEmployeeByIdQuery(long id)
        {
            Id = id;
        }
    }
}
