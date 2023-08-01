using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionTH.API.Validation;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Domain.Enum;

namespace SistemaGestionTH.APIResfull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _managementService;
        public AreasController(IAreaService areasServices)
        {
            _managementService = areasServices;
        }

        [HttpGet("GetListAreas")]
        public async Task<ActionResult<IEnumerable<AreasDto>>> GetListAreas()
        {
            var areas = await _managementService.GetListAreasAsync();


            if (areas == null || areas.Count() == 0)
                return BadRequest("La lista de areas son nulas o no hay en la base de datos");

            var Sendareas = areas.Select(resp =>
            {
                return new
                {
                    Id = resp.Id,
                    Name = resp.Name
                 
                };
            });


            return Ok(Sendareas);
        }

        [HttpGet("GetAreasById")]
        public async Task<ActionResult<AreasDto>> GetAreasById(long? id)
        {
            if (AreasValidation.ValidationIdAreaDto(id))
                return BadRequest($"Error al diligenciar el identificador para la creacion del empleado");

            var area = await _managementService.GetAreaByIdAsync(id);

            if (area == null)
                return NotFound("No existe area con el identificador " + id );

            return Ok(area);
        }

        [HttpPost("CreateArea")]
        public async Task<ActionResult<AreasDto>> CreateArea(AreasDto areaDto)
        {
            if(AreasValidation.ValidationCreateAreaDto(areaDto))
                return BadRequest($"Error al diligenciar los campos de creacion del empleado"); 

            await _managementService.CreatedAreaAsync(areaDto);

            return Ok("Area creada de manera exitosa!");
        }

        [HttpPut("UpdateArea")]
        public async Task<ActionResult<AreasDto>> UpdateArea(AreasDto areaDto)
        {
            if (AreasValidation.ValidationUpdateAreaDto(areaDto))
                return BadRequest($"Error al diligenciar  los campos de la creacion del empleado");

            await _managementService.UpdateAreaAsync(areaDto);

            return Ok("Area actualizada correctamente");
            
        }

        [HttpDelete("DeleteArea")]
        public async Task<ActionResult<AreasDto>> DeleteArea(long? id)
        {
            if (AreasValidation.ValidationIdAreaDto(id))
                return BadRequest($"Error al diligenciar el identificador para de creacion del empleado");

            await _managementService.DeleteAreaAsync(id);

            return Ok("Area eliminanda correctamente");
        }

    }
}
