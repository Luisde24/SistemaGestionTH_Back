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
    public class DeleteEmployeesCommandHandler : IRequestHandler<DeleteEmployeesCommand, Employees>
    {
        private readonly IEmployeesRepository _employeeRepository;
        public DeleteEmployeesCommandHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employees> Handle(DeleteEmployeesCommand request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetEmployeeByIdAsync(request.Id);

            if (employees == null)
                throw new ApplicationException($"Error al eliminar la entidad empleados");

            return  await _employeeRepository.DeleteEmployeeAsync(employees);

        }
    }
}
