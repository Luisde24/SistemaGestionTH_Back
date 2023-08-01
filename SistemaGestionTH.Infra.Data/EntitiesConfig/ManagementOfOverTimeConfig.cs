using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionTH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Infra.Data.EntitiesConfig
{
    public class ManagementOfOverTimeConfig : IEntityTypeConfiguration<ManagementOfOverTime>
    {
        public void Configure(EntityTypeBuilder<ManagementOfOverTime> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(n => n.Reason)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(n => n.AdditionalTime)
                   .IsRequired();

            builder.Property(n => n.DateOfRequest)
                   .IsRequired();

            builder.Property(n => n.DateOfResponse);

            builder.Property(n => n.State)
                   .IsRequired();

            builder.HasOne(e => e.Areas)
                   .WithMany(e => e.ManagementOfOverTime)
                   .HasForeignKey(e => e.AreaId);

            builder.HasOne(e => e.Employees)
               .WithMany(e => e.ManagementOfOverTime)
               .HasForeignKey(e => e.EmployeesId);

        }
    }
}
