using Microsoft.EntityFrameworkCore;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Interfaces;
using SistemaGestionTH.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Infra.Data.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employees> CreatedEmployeeAsync(Employees employees)
        {
            _context.Empleados.Add(employees);
            await _context.SaveChangesAsync();

            return employees;
        }

        public async Task<Employees> DeleteEmployeeAsync(Employees employees)
        {
            _context.Empleados.Remove(employees);
            await _context.SaveChangesAsync();

            return employees;
        }

        public async Task<Employees> GetEmployeeByIdAsync(long? id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<IEnumerable<Employees>> GetListEmployeesAsync()
        {
            return await _context.Empleados.Include(a => a.Areas).ToListAsync();
        }

        public async Task<Employees> UpdateEmployeeAsync(Employees employees)
        {
            _context.Empleados.Update(employees);
            await _context.SaveChangesAsync();

            return employees;
        }
    }
}
