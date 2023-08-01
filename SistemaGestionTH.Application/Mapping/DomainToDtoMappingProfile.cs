using AutoMapper;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Application.Mapping
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Employees, EmployeesDto>().ReverseMap();
            CreateMap<Areas, AreasDto>().ReverseMap();
            CreateMap<ManagementOfOverTime, ManagementOfOverTimeDto>().ReverseMap();
        }
    }
}
