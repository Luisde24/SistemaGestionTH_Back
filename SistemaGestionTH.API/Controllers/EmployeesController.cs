using Microsoft.AspNetCore.Mvc;
using SistemaGestionTH.APIResfull.Validation;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Enum;

namespace SistemaGestionTH.APIResfull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeesService;
        public EmployeesController(IEmployeeService employeesService)
        {
            _employeesService   = employeesService;
        }

        [HttpGet("GetListEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeesDto>>> GetListEmployees()
        {
            var employees = await _employeesService.GetListEmployeesAsync();
            
            if(employees == null || employees.Count() == 0)
                return BadRequest("La lista de empleados son nulas o no hay en la base de datos");

            var SendEmployees = employees.Select(resp =>
            {
                return new
                {
                    Id = resp.Id,
                    Nombres = resp.Name,
                    Apellidos = resp.Lastname,
                    TipoIdentificacion = Enum.GetName(typeof(TypeIdentificactionEnum), resp.TypeIdentification),
                    TipoIdentificacionId =  resp.TypeIdentification,
                    Identificacion = resp.Identification,
                    Correo = resp.Email,
                    Celular = resp.Phone,
                    Areas = resp.Areas.Name,
                    AreaId = resp.AreaId

                };
            });

            return Ok(SendEmployees);
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<EmployeesDto>> GetEmployee(long? id)
        {
            if (EmployeesValidation.ValidationIdEmployeesDto(id))
                return BadRequest($"Error al diligenciar el identificador para la creacion del empleado");

            var employees = await _employeesService.GetEmployeeByIdAsync(id);

            if (employees == null)
                return NotFound("No existe empleados en la base de datos con el identificador " + id);

            return Ok(employees);
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<EmployeesDto>> CreateEmployee(EmployeesDto employeesDto)
        {
            if (EmployeesValidation.ValidationCreateEmployeesDto(employeesDto))
                return BadRequest($"Error al diligenciar los campos de creacion del empleado");

            await _employeesService.CreatedEmployeeAsync(employeesDto);

            return Ok("Empleado creado correctamente");
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<EmployeesDto>> UpdateEmployees(EmployeesDto employeesDto)
        {

            if (EmployeesValidation.ValidationUpdateEmployeesDto(employeesDto))
                return BadRequest($"Error al diligenciar los campos de creacion del empleado");

            var employee = await _employeesService.GetEmployeeByIdAsync(employeesDto.Id);

            if (employee == null)
                return NotFound("La información del empleado es nula");

            await _employeesService.UpdateEmployeeAsync(employeesDto);

            return Ok("Empleado Actualizado correctamente");
        }

        [HttpDelete("DeleteEmployeesById")]
        public async Task<ActionResult<EmployeesDto>> DeleteEmployeesById(long? id)
        {
            if (EmployeesValidation.ValidationIdEmployeesDto(id))
                return BadRequest($"Error al diligenciar el identificador para la creacion del empleado");

            await _employeesService.DeleteEmployeeAsync(id);

            return Ok("Empleado Elimanado correctamente");
        }
    }
}
