using AutoMapper;
using MediatR;
using SistemaGestionTH.Application.Employee.Queries;
using SistemaGestionTH.Application.Employee.Commands;
using SistemaGestionTH.Application.Employee.Queries;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;

namespace SistemaGestionTH.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EmployeeService(IMapper mapper,  IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreatedEmployeeAsync(EmployeesDto employees)
        {
            var employeesCreateCommand = _mapper.Map<CreatedEmployeesCommand>(employees);
            await _mediator.Send(employeesCreateCommand);
        }

        public async Task DeleteEmployeeAsync(long? id)
        {
            var employeesRemoveCommand = new DeleteEmployeesCommand(id.Value);

            if (employeesRemoveCommand == null)
                throw new Exception($"Error al cargar la entidad.");

            await _mediator.Send(employeesRemoveCommand);
        }

        public async Task<EmployeesDto> GetEmployeeByIdAsync(long? id)
        {

            var employeesByIdQuery = new GetEmployeeByIdQuery(id.Value);

            if(employeesByIdQuery == null)
                throw new Exception($"Error al cargar la entidad");

            var result = await _mediator.Send(employeesByIdQuery);
            return _mapper.Map<EmployeesDto>(result);
        }

        public async Task<IEnumerable<EmployeesDto>> GetListEmployeesAsync()
        {
            var employeesQuery = new GetEmployeesQuery();
            if (employeesQuery == null)
                throw new Exception($"Error al cargar la entidad");

            var result = await _mediator.Send(employeesQuery);

            return _mapper.Map<IEnumerable<EmployeesDto>>(result);
        }

        public async Task UpdateEmployeeAsync(EmployeesDto employees)
        {
            var employeesUpdateCommand = _mapper.Map<UpdateEmployeesCommand>(employees);
            await _mediator.Send(employeesUpdateCommand);
        }
    }
}
