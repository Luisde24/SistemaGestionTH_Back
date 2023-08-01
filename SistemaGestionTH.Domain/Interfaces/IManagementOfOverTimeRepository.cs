using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Interfaces
{
    public interface IManagementOfOverTimeRepository
    {
        Task<IEnumerable<ManagementOfOverTime>> GetListManagementOfOverTimesAsync();
        Task<ManagementOfOverTime> GetManagementOfOverTimeByIdAsync(long? id);
        Task<ManagementOfOverTime> CreatedManagementOfOverTimeAsync(ManagementOfOverTime overTime);
        Task<ManagementOfOverTime> UpdateManagementOfOverTimeAsync(ManagementOfOverTime overTime);
        Task<ManagementOfOverTime> DeleteManagementOfOverTimeAsync(ManagementOfOverTime overTime);
    }
}
