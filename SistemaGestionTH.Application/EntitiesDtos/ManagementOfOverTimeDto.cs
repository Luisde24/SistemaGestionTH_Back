using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionTH.Domain.Entities;
using System.Text.Json.Serialization;

namespace SistemaGestionTH.Application.EntitiesDtos
{
    public class ManagementOfOverTimeDto
    {
        public long Id { get; set; }
        public string Reason { get;  set; }
        public int AdditionalTime { get;  set; }
        public DateTime DateOfRequest { get;  set; }
        public string Leader { get;  set; }
        public int State { get; set; }
        public int TypeRemuneration { get; set; }
    
        public long EmployeesId { get; set; }
        [JsonIgnore]
        public Employees? Employees { get; set; }
    
        public long AreaId { get; set; }
        [JsonIgnore]
        public Areas? Areas { get; set; }
    }
}
