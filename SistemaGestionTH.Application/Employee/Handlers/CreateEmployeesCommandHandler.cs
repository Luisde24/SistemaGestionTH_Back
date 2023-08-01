using MediatR;
using SistemaGestionTH.Application.Employee.Commands;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Employee.Handlers
{
    public class CreateEmployeesCommandHandler : IRequestHandler<CreatedEmployeesCommand, Employees>
    {
        private readonly IEmployeesRepository _employeeRepository;
        public CreateEmployeesCommandHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employees> Handle(CreatedEmployeesCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employees(request.Id, request.Name.ToLower(), request.Lastname.ToLower(), request.TypeIdentification, request.Identification, request.Email.ToLower(), request.Phone);
            if (employee == null)
            {
                throw new ApplicationException($"Error al crear la entidad empleados");
            }

            employee.AreaId = request.AreaId;
            return await _employeeRepository.CreatedEmployeeAsync(employee);
        }
    }
}
