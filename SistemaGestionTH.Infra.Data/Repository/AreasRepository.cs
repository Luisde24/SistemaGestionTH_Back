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
    public class AreasRepository : IAreasRepository
    {
        private readonly ApplicationDbContext _context;
        public AreasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Areas> CreatedAreaAsync(Areas areas)
        {
            _context.Areas.Add(areas);
            await _context.SaveChangesAsync();

            return areas;
        }

        public async Task<Areas> DeleteAreaAsync(Areas areas)
        {
            _context.Remove(areas);
            await _context.SaveChangesAsync();

           return areas;
        }

        public async Task<Areas> GetAreaByIdAsync(long? id)
        {
            return await _context.Areas.FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<IEnumerable<Areas>> GetListAreasAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Areas> UpdateAreaAsync(Areas areas)
        {
            _context.Areas.Update(areas);
            await _context.SaveChangesAsync();

            return areas;
        }
    }
}
