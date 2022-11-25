using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaServicio _polizaServicio;
        private readonly IMapper _mapper;

        public PolizaController(IPolizaServicio polizaServicio,IMapper mapper) {
            _polizaServicio = polizaServicio;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos los polizas
        /// </summary>
        /// <returns></returns>
        //[HttpGet(Name = nameof(obtenerPaises)]
        //[ProducesResponseType((int)HttpStatusCode.OK,Type = typeof())]
        [HttpGet]
        [Route("obtenerPolizas")]
        public IActionResult obtenerPolizas()
        {
            var polizas = _polizaServicio.ObtenerPolizas();
            var polizasDTO = _mapper.Map<IEnumerable<PolizaDTO>>(polizas);
            var respuesta = new ApiRespuesta<IEnumerable<PolizaDTO>>(polizasDTO);
            return Ok(respuesta);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("obtenerPoliza/{id}")]
        public async Task<IActionResult> obtenerPoliza(int id)
        {
            var poliza = await _polizaServicio.ObtenerPoliza(id);
            var polizaDTO = _mapper.Map<PolizaDTO>(poliza);
            var respuesta = new ApiRespuesta<PolizaDTO>(polizaDTO);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("insertarPoliza")]
        public async Task<IActionResult> insertarPoliza(PolizaDTO polizaDTO)
        {
            var poliza = _mapper.Map<Poliza>(polizaDTO);

            await _polizaServicio.InsertarPoliza(poliza);

            polizaDTO = _mapper.Map<PolizaDTO>(poliza);

            var respuesta = new ApiRespuesta<PolizaDTO>(polizaDTO);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("modificarPoliza/{id}")]
        public async Task<IActionResult> modificarPoliza(int id, PolizaDTO polizaDTO)
        {
            var poliza = _mapper.Map<Poliza>(polizaDTO);

            poliza.Id = id;

            var resultado = await _polizaServicio.ModificarPoliza(poliza);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminarPoliza/{id}")]
        public async Task<IActionResult> eliminarPoliza(int id)
        {
            var resultado = await _polizaServicio.EliminarPoliza(id);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }
    }
}
