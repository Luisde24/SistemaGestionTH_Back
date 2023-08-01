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
    public sealed class ManagementOfOverTime : BaseEntity
    {
        public string Reason { get; private set; } 
        public int AdditionalTime { get; private set; }
        public DateTime? DateOfRequest { get; private set; }
        public string Leader { get; private set; }
        public DateTime? DateOfResponse { get; private set; }
        public StateEnum State { get; set; }
        public TypeRemunerationEnum TypeRemuneration { get; set; }
        public long EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public long AreaId { get; set; }
        public Areas Areas { get; set; }
   

        public ManagementOfOverTime(long id, string reason, int additionalTime, DateTime dateOfRequest, string leader , StateEnum state, TypeRemunerationEnum typeRemuneration)
        {
            ValidateDomain.validationManejoHorasExtras(reason, additionalTime, dateOfRequest);
            Reason = reason;
            AdditionalTime = additionalTime;
            DateOfRequest = dateOfRequest;
            Leader = leader;
            State = state;
            TypeRemuneration = typeRemuneration;
        }

        public ManagementOfOverTime(/*long id, string reason, int additionalTime, DateTime dateOfRequest, string leader, StateEnum state, TypeRemunerationEnum typeRemuneration*/)
        {
            //ValidateDomain.ValidateDominanId(id);
            //ValidateDomain.validationManejoHorasExtras(reason, additionalTime, dateOfRequest);
            //Reason = reason;
            //AdditionalTime = additionalTime;
            //DateOfRequest = dateOfRequest;
            //Leader = leader;
            //State = state;
            //TypeRemuneration = typeRemuneration;
        }

       public void UpdateManejoHorasExtras(string reason, int additionalTime, DateTime dateOfRequest, string leader, StateEnum state, TypeRemunerationEnum typeRemuneration, long employeesId, long areaId )
        {
            ValidateDomain.validationManejoHorasExtras(reason, additionalTime, dateOfRequest);
            Reason = reason;
            AdditionalTime = additionalTime;
            DateOfRequest = dateOfRequest;
            Leader = leader;
            State = state;
            TypeRemuneration = typeRemuneration;
            EmployeesId = employeesId;
            AreaId = areaId;
          
        }

    }
}
