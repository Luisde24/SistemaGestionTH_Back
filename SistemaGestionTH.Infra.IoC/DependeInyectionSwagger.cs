using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SistemaGestionTH.Application.Area.Commands;
using SistemaGestionTH.Application.Employee.Commands;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Application.ManagementOverTime.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Infra.IoC
{
    public static class DependeInyectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
           
            //Inyecciones de los mapeos en command
           services.AddSwaggerGen(options =>
            {
                //Defino titulo de la API
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaGestionTH.API", Version = "v1" });
                //Defino esquema
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    //Interfaz en swagger
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Para la autorización de JWT, debe colocar la palabra Bearer colocar un espacio y pegar el token generado"

                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
               Reference = new OpenApiReference
               {
                   Type = ReferenceType.SecurityScheme,
                   Id = "Bearer"
               }
            },
            new string[] {}
        }

    });
            });

            return services;
        }
    }
}
