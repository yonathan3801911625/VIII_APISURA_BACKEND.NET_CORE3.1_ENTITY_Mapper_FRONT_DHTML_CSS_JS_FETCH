using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Infraestructura.Datos.Configuraciones;

namespace PolizasVehiculos.Infraestructura.Datos
{
    public partial class DBSegurosContext : DbContext
    {
        public DBSegurosContext()
        {
        }

        public DBSegurosContext(DbContextOptions<DBSegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoPais> ProductoPais { get; set; }
        public virtual DbSet<ProductoPoliza> ProductoPoliza { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<VehiculoUsuario> VehiculoUsuario { get; set; }

        public virtual DbSet<Seguridad> Seguridad { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MZLNB064;Database=DBSeguros;Integrated Security = true");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisConfiguracion());

            modelBuilder.ApplyConfiguration(new SeguridadConfiguracion());

            //Llamar nivel general las configuraciones
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idPoliza")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaVigenciaPoliza)
                    .HasColumnName("fechaVigenciaPoliza")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdVehiculoUsuario).HasColumnName("idVehiculoUsuario");

                entity.HasOne(d => d.VehiculoUsuario)
                    .WithMany(p => p.Poliza)
                    .HasForeignKey(d => d.IdVehiculoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poliza_VehiculoUsuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idProducto")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("nombreProducto")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoProducto)
                    .IsRequired()
                    .HasColumnName("tipoProducto")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductoPais>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idProductoPais")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.ProductoPais)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pais_ProductoPais");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoPais)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoPais_Producto");
            });

            modelBuilder.Entity<ProductoPoliza>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idProductoPoliza")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPoliza).HasColumnName("idPoliza");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.Poliza)
                    .WithMany(p => p.ProductoPoliza)
                    .HasForeignKey(d => d.IdPoliza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoPoliza_Poliza");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoPoliza)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoPoliza_Producto");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidosUsuario)
                    .IsRequired()
                    .HasColumnName("apellidosUsuario")
                    .HasMaxLength(50);

                entity.Property(e => e.LoginUsuario)
                    .IsRequired()
                    .HasColumnName("loginUsuario")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(50);

                entity.Property(e => e.NumIdentificacionUsuario)
                    .IsRequired()
                    .HasColumnName("numIdentificacionUsuario")
                    .HasMaxLength(15);

                entity.Property(e => e.PasswordUsuario)
                    .IsRequired()
                    .HasColumnName("passwordUsuario")
                    .HasMaxLength(40);

                entity.Property(e => e.TipoDocUsuario)
                    .IsRequired()
                    .HasColumnName("tipoDocUsuario")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idVehiculo")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaVehiculo)
                    .IsRequired()
                    .HasColumnName("marcaVehiculo")
                    .HasMaxLength(20);

                entity.Property(e => e.PlacaVehiculo)
                    .IsRequired()
                    .HasColumnName("placaVehiculo")
                    .HasMaxLength(20);

                entity.Property(e => e.VinVehiculo)
                    .IsRequired()
                    .HasColumnName("vinVehiculo")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VehiculoUsuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("idVehiculoUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.VehiculoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculoUsuario_Usuario");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.VehiculoUsuario)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculoUsuario_Vehiculo");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
