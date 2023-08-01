using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using SistemaGestionTH.Domain.Enum;

namespace SistemaGestionTH.Application.EntitiesDtos
{
    public class EmployeesDto
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Lastname { get;  set; }
        public int TypeIdentification { get;  set; }
        public string Identification { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        [JsonIgnore]
        public Areas? Areas { get; set; }
   
        public long AreaId { get; set; }


    }
}
