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
    public class UpdateEmployeesQueryHandler : IRequestHandler<UpdateEmployeesCommand, Employees>
    {
        private readonly IEmployeesRepository _employeeRepository;
        public UpdateEmployeesQueryHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employees> Handle(UpdateEmployeesCommand request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employees == null)
                throw new ApplicationException($"Error al crear la entidad empleados");

            employees.UpdateEmployees(request.Name.ToLower(), request.Lastname.ToLower(), request.TypeIdentification, request.Identification, request.Email.ToLower(), request.Phone, request.AreaId);

            return await _employeeRepository.UpdateEmployeeAsync(employees);

        }
    }
}
