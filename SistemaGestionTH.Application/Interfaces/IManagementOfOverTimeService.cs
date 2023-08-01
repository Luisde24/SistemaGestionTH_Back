using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Interfaces
{
    public interface IManagementOfOverTimeService
    {
        Task<IEnumerable<ManagementOfOverTimeDto>> GetListManagementOfOverTimesAsync();
        Task<ManagementOfOverTimeDto> GetManagementOfOverTimeByIdAsync(long? id);
        Task CreatedManagementOfOverTimeAsync(ManagementOfOverTimeDto overTime);
        Task UpdateManagementOfOverTimeAsync(ManagementOfOverTimeDto overTime);
        Task DeleteManagementOfOverTimeAsync(long? id);
    }
}
