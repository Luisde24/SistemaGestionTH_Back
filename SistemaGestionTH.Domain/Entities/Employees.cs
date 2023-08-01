using SistemaGestionTH.Domain.Enum;
using SistemaGestionTH.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaGestionTH.Domain.Entities
{
    public class Employees : BaseEntity
    {
       public string Name { get; private set; }
       public string Lastname { get; private set; }
       public TypeIdentificactionEnum TypeIdentification { get; private set; }
       public string Identification { get; private set; }
       public string Email { get; private set; }
       public string Phone { get; private set; }
        public long AreaId { get; set; }
        public Areas Areas { get; set; }

        public ICollection<ManagementOfOverTime> ManagementOfOverTime { get; set; }

        public Employees()
        {
            

        }

        public Employees(long id, string name, string lastName, TypeIdentificactionEnum typeIdenification, string identifiction, string email, string phone )
        {
            ValidateDomain.ValidateDominanId(id);
            ValidateDomain.validationEmployees(name, lastName, typeIdenification, identifiction, email, phone);
            Name = name;
            Lastname = lastName;
            TypeIdentification = typeIdenification;
            Identification = identifiction;
            Email = email;
            Phone = phone;
        
        }

        public void UpdateEmployees(string name, string lastName, TypeIdentificactionEnum typeIdenification, string identifiction, string email, string phone , long areaId)
        {
            ValidateDomain.validationEmployees(name, lastName, typeIdenification, identifiction, email, phone);
            Name = name;
            Lastname = lastName;
            TypeIdentification = typeIdenification;
            Identification = identifiction;
            Email = email;
            Phone = phone;
            AreaId = areaId;

        }
    }
}
