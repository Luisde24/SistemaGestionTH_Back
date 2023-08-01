using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Interfaces
{
    public  interface IAreasRepository
    {
        Task<IEnumerable<Areas>> GetListAreasAsync();
        Task<Areas> GetAreaByIdAsync(long? id);
        Task<Areas> CreatedAreaAsync(Areas areas);
        Task<Areas> UpdateAreaAsync(Areas areas);
        Task<Areas> DeleteAreaAsync(Areas areas);
    }
}
