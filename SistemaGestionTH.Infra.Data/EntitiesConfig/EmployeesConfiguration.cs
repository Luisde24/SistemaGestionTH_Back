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
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(n => n.Lastname)
                   .HasMaxLength(100)
                    .IsRequired();

            builder.Property(n => n.TypeIdentification)
                  .HasMaxLength(30)
                   .IsRequired();

            builder.Property(n => n.Identification)
                  .HasMaxLength(15)
                   .IsRequired();

            builder.Property(n => n.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(n => n.Phone)
                 .HasMaxLength(15)
                  .IsRequired();

            builder.HasOne(e => e.Areas)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(e => e.AreaId);


        }
    }
}
