using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionTH.Application.Area.Commands;
using SistemaGestionTH.Application.Employee.Commands;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.Interfaces;
using SistemaGestionTH.Application.ManagementOverTime.Commands;
using SistemaGestionTH.Application.Mapping;
using SistemaGestionTH.Application.Services;
using SistemaGestionTH.Domain.Interfaces;
using SistemaGestionTH.Infra.Data.Context;
using SistemaGestionTH.Infra.Data.Identity;
using SistemaGestionTH.Infra.Data.Repository;

namespace SistemaGestionTH.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            //Inyeccion de Repositorios
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IAreasRepository, AreasRepository>();
            services.AddScoped<IManagementOfOverTimeRepository, ManagementOfOverTimeRepository>();

            //Inyeccion de servicios
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IManagementOfOverTimeService, ManagementOfOverTimeService>();

            services.AddScoped<IAuthenticate, Authenticate>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //Inyecciones de los mapeos en command
            services.AddAutoMapper(config =>
            {
                config.CreateMap<EmployeesDto, CreatedEmployeesCommand>()
                      .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId));

                config.CreateMap<EmployeesDto, UpdateEmployeesCommand>()
                      .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId));

                config.CreateMap<AreasDto, CreateAreaCommand>();

                config.CreateMap<AreasDto, UpdateAreaCommand>();

                config.CreateMap<ManagementOfOverTimeDto, CreateManagementOfOverTimeCommand>()
                      .ForMember(dest => dest.EmployeesId, opt => opt.MapFrom(src => src.EmployeesId))
                      .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId));

                config.CreateMap<ManagementOfOverTimeDto, UpdateManagementOfOverTimeCommand>()
                      .ForMember(dest => dest.EmployeesId, opt => opt.MapFrom(src => src.EmployeesId))
                      .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId));

                //config.CreateMap<EmployeesDto, EMP>()
                //      .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreasId));
            });

         
           
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("SistemaGestionTH.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }

}