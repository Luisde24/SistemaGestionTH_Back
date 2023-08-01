using MediatR;
using SistemaGestionTH.Application.Employee.Queries;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Handlers
{
    public class GetEmployeesByIdQuerysHandler : IRequestHandler<GetEmployeeByIdQuery, Employees>
    {
        private readonly IEmployeesRepository _employeesRepository;
        public GetEmployeesByIdQuerysHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<Employees> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
