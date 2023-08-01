using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employees>> GetListEmployeesAsync();
        Task<Employees> GetEmployeeByIdAsync(long? id);
        Task<Employees> CreatedEmployeeAsync(Employees employees);
        Task<Employees> UpdateEmployeeAsync(Employees employees);
        Task<Employees> DeleteEmployeeAsync(Employees employees);
    }
}
