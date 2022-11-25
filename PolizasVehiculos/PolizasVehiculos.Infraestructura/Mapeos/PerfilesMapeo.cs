using AutoMapper;
using PolizasVehiculos.Core.DTOs;
using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Mapeos
{
    public class PerfilesMapeo : Profile
    {
        public PerfilesMapeo() {
            CreateMap<Pais, PaisDTO>().ReverseMap();
            CreateMap<Seguridad, SeguridadDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<ProductoPais, ProductoPaisDTO>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<VehiculoUsuario, VehiculoUsuarioDTO>().ReverseMap();
            CreateMap<Poliza, PolizaDTO>().ReverseMap();
            CreateMap<ProductoPoliza, ProductoPolizaDTO>().ReverseMap();
        }
    }
}
