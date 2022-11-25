using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Datos.Configuraciones
{
    public class SeguridadConfiguracion : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            builder.ToTable("Seguridad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("idSeguridad")
                .ValueGeneratedNever();

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasColumnName("usuario")
                .HasMaxLength(50);

            builder.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasColumnName("nombreUsuario")
                .HasMaxLength(100);

            builder.Property(e => e.Contrasena)
                .IsRequired()
                .HasColumnName("Contrasena")
                .HasMaxLength(200);

            builder.Property(e => e.Rol)
                .IsRequired()
                .HasColumnName("rol")
                .HasMaxLength(15)
                .HasConversion(x=>x.ToString(),x=>(TiposRoles)Enum.Parse(typeof(TiposRoles),x));
        }
    }
}
