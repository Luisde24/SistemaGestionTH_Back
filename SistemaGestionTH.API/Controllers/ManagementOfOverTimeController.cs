using Microsoft.AspNetCore.Mvc;
using SistemaGestionTH.API.Validation;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Domain.Enum;
using System;

namespace SistemaGestionTH.APIResfull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementOfOverTimeController : ControllerBase
    {
        private readonly IManagementOfOverTimeService _managementService;
        public ManagementOfOverTimeController(IManagementOfOverTimeService managementService)
        {
            _managementService = managementService;       
        }

        [HttpGet("GetListOverTime")]
        public async Task<ActionResult<IEnumerable<ManagementOfOverTimeDto>>> GetListOverTime()
        {
            var management = await _managementService.GetListManagementOfOverTimesAsync();

            if (management == null || management.Count() == 0)
                return BadRequest("Los registros son nulas o no hay en la base de datos");

            var managementConverted = management.Select(resp =>
            {
                return new
                {
                    Id = resp.Id,
                    Motivo = resp.Reason,
                    HorasExtras = resp.AdditionalTime,
                    FechaSolicitud = resp.DateOfRequest,
                    LiderArea = resp.Leader,
                    TipoRemuneracion = Enum.GetName(typeof(TypeRemunerationEnum), resp.TypeRemuneration),
                    TipoRemuneracionId =  resp.TypeRemuneration,
                    Estado = Enum.GetName(typeof(StateEnum), resp.State),
                    Area = resp.Areas?.Name,
                    AreaId = resp.AreaId,
                    Empleado = resp.Employees?.Name + ' ' + resp.Employees?.Lastname,
                    EmpleadoId = resp.EmployeesId
                };
            });

            return Ok(managementConverted);
        }

        [HttpGet("GetOverTimeById")]
        public async Task<ActionResult<ManagementOfOverTimeDto>> GetOverTimeById(long? id)
        {
            if (OverTimeValidation.ValidationIdOverTimeDto(id))
                return BadRequest($"Error al diligenciar el identificador para la creacion del regsitro");

            var management = await _managementService.GetManagementOfOverTimeByIdAsync(id);

            if (management == null)
                return NotFound("No existe area con el id " + id);

            return Ok(management);
        }

        [HttpPost("CreateOverTime")]
        public async Task<ActionResult<ManagementOfOverTimeDto>> CreateOverTime(ManagementOfOverTimeDto managementDto)
        {
            if (OverTimeValidation.ValidationCreateOverTimeDto(managementDto))
                return BadRequest($"Error al diligenciar los campos para la creacion del regsitro");

            await _managementService.CreatedManagementOfOverTimeAsync(managementDto);

            return Ok("Registro creada de manera exitosa!");
        }

        [HttpPut("UpdateOverTime")]
        public async Task<ActionResult<ManagementOfOverTimeDto>> UpdateOverTime(ManagementOfOverTimeDto managementDto)
        {
            if (OverTimeValidation.ValidationUpdateOverTimeDto(managementDto))
                return BadRequest($"Error al diligenciar los campos para la creacion del regsitro");

            await _managementService.UpdateManagementOfOverTimeAsync(managementDto);

            return Ok("Registro actualizado correctamente");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ManagementOfOverTimeDto>> DeleteOverTime(long? id)
        {
            if (OverTimeValidation.ValidationIdOverTimeDto(id))
                return BadRequest($"Error al diligenciar el identificador para la creacion del regsitro");

            await _managementService.DeleteManagementOfOverTimeAsync(id);

            return Ok("Registro eliminando correctamente");
        }
    }
}
