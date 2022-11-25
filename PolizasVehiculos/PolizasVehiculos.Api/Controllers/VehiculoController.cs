using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolizasVehiculos.Api.ApiRespuesta;
using PolizasVehiculos.Core.DTOs;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoServicio _vehiculoServicio;
        private readonly IMapper _mapper;

        public VehiculoController(IVehiculoServicio vehiculoServicio, IMapper mapper) {
            _vehiculoServicio = vehiculoServicio;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos los vehiculos
        /// </summary>
        /// <returns></returns>
        //[HttpGet(Name = nameof(obtenerPaises)]
        //[ProducesResponseType((int)HttpStatusCode.OK,Type = typeof())]
        [HttpGet]
        [Route("obtenerVehiculos")]
        public IActionResult obtenerVehiculos()
        {
            var vehiculos = _vehiculoServicio.ObtenerVehiculos();
            var vehiculosDTO = _mapper.Map<IEnumerable<VehiculoDTO>>(vehiculos);
            var respuesta = new ApiRespuesta<IEnumerable<VehiculoDTO>>(vehiculosDTO);
            return Ok(respuesta);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("obtenerVehiculo/{id}")]
        public async Task<IActionResult> obtenerVehiculo(int id)
        {
            var vehiculo = await _vehiculoServicio.ObtenerVehiculo(id);
            var vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculo);
            var respuesta = new ApiRespuesta<VehiculoDTO>(vehiculoDTO);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("insertarVehiculo")]
        public async Task<IActionResult> insertarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);

            await _vehiculoServicio.InsertarVehiculo(vehiculo);

            vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

            var respuesta = new ApiRespuesta<VehiculoDTO>(vehiculoDTO);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("modificarVehiculo/{id}")]
        public async Task<IActionResult> modificarVehiculo(int id, VehiculoDTO vehiculoDTO)
        {
            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);

            vehiculo.Id = id;

            var resultado = await _vehiculoServicio.ModificarVehiculo(vehiculo);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminarVehiculo/{id}")]
        public async Task<IActionResult> eliminarVehiculo(int id)
        {
            var resultado = await _vehiculoServicio.EliminarVehiculo(id);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }
    }
}
