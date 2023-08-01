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
    public class AreasConfiguration : IEntityTypeConfiguration<Areas>
    {
        public void Configure(EntityTypeBuilder<Areas> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsRequired();

           
        }
    }
}
