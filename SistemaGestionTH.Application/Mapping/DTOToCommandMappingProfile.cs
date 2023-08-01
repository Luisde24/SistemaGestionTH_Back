using AutoMapper;
using SistemaGestionTH.Application.Employee.Commands;
using SistemaGestionTH.Application.EntitiesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<EmployeesDto, CreatedEmployeesCommand>();
            CreateMap<EmployeesDto, UpdateEmployeesCommand>();
        }
    }
}
