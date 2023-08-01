using SistemaGestionTH.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Entities
{
    public sealed class Areas : BaseEntity
    {
        public string Name { get; private set; }
    

        public Areas(string name)
        {
            ValidateDomain.validationAreas(name);
            Name = name;
        }
        public Areas(long id, string name)
        {
            ValidateDomain.ValidateDominanId(id);
            ValidateDomain.validationAreas(name);
            Id = id;
            Name = name;
        }

        public ICollection<Employees> Employees { get; set; }
        public ICollection<ManagementOfOverTime> ManagementOfOverTime { get; set; }

        public void UpdateAreas(string name)
        {
            ValidateDomain.validationAreas(name);
            Name = name;
        }
    }
}
