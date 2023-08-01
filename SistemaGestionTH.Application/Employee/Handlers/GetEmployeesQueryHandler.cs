using MediatR;
using SistemaGestionTH.Application.Employee.Queries;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion.Application.Employee.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employees>>
    {
        private readonly IEmployeesRepository _employeeRepository;
        public GetEmployeesQueryHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employees>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetListEmployeesAsync();
        }
    }
}
