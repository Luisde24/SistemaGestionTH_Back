using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeesDto>> GetListEmployeesAsync();
        Task<EmployeesDto> GetEmployeeByIdAsync(long? id);
        Task CreatedEmployeeAsync(EmployeesDto employees);
        Task UpdateEmployeeAsync(EmployeesDto employees);
        Task DeleteEmployeeAsync(long? id);
    }
}
