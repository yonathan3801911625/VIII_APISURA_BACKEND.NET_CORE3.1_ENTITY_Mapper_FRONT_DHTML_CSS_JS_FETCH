using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Datos.Configuraciones
{
    public class PaisConfiguracion : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("idPais")
                .ValueGeneratedNever();

            builder.Property(e => e.NombrePais)
                .IsRequired()
                .HasColumnName("nombrePais")
                .HasMaxLength(50);

            builder.Property(e => e.SubContiente)
                .IsRequired()
                .HasColumnName("subContiente")
                .HasMaxLength(50);
        }
    }
}
