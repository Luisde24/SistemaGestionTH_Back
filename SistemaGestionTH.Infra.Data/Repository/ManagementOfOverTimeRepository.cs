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
    public class ManagementOfOverTimeRepository : IManagementOfOverTimeRepository
    {
        private readonly ApplicationDbContext _context;
        public ManagementOfOverTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagementOfOverTime> CreatedManagementOfOverTimeAsync(ManagementOfOverTime overTime)
        {
            _context.HorasExtras.Add(overTime);
            await _context.SaveChangesAsync();

            return overTime;
        }

        public async Task<ManagementOfOverTime> DeleteManagementOfOverTimeAsync(ManagementOfOverTime overTime)
        {
            _context.HorasExtras.Remove(overTime);
            await _context.SaveChangesAsync();

            return overTime;
        }

        public async Task<IEnumerable<ManagementOfOverTime>> GetListManagementOfOverTimesAsync()
        {
            return await _context.HorasExtras.Include(e => e.Employees)
                                             .Include(a => a.Areas)
                                             .ToListAsync();
        }

        public async Task<ManagementOfOverTime> GetManagementOfOverTimeByIdAsync(long? id)
        {
            return await _context.HorasExtras.FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<ManagementOfOverTime> UpdateManagementOfOverTimeAsync(ManagementOfOverTime overTime)
        {
            _context.HorasExtras.Update(overTime);
            await _context.SaveChangesAsync();

            return overTime;
        }
    }
}
