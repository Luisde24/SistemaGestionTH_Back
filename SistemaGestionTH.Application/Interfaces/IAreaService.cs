using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<AreasDto>> GetListAreasAsync();
        Task<AreasDto> GetAreaByIdAsync(long? id);
        Task CreatedAreaAsync(AreasDto areasDto);
        Task UpdateAreaAsync(AreasDto areasDto);
        Task DeleteAreaAsync(long? id);
    }
}
