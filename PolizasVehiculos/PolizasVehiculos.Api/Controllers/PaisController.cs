using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PolizasVehiculos.Api.ApiRespuesta;
using PolizasVehiculos.Core.DTOs;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisServicio _paisServicio;
        private readonly IMapper _mapper;

        public PaisController(IPaisServicio paisServicio, IMapper mapper) 
        {
            _paisServicio = paisServicio;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos los paises
        /// </summary>
        /// <returns></returns>
        //[HttpGet(Name = nameof(obtenerPaises)]
        //[ProducesResponseType((int)HttpStatusCode.OK,Type = typeof())]
        [HttpGet]
        [Route("obtenerPaises")]
        public IActionResult obtenerPaises() {
            var paises =  _paisServicio.ObtenerPaises();
            var paisesDTO = _mapper.Map<IEnumerable<PaisDTO>>(paises);
            var respuesta = new ApiRespuesta<IEnumerable<PaisDTO>>(paisesDTO);
            return Ok(respuesta);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("obtenerPais/{id}")]
        public async Task<IActionResult> obtenerPais(int id)
        {
            var pais = await _paisServicio.ObtenerPais(id);
            var paisDTO = _mapper.Map<PaisDTO>(pais);
            var respuesta = new ApiRespuesta<PaisDTO>(paisDTO);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("insertarPais")]
        public async Task<IActionResult> insertarPais(PaisDTO paisDTO) 
        {
            var pais = _mapper.Map<Pais>(paisDTO);

            await _paisServicio.InsertarPais(pais);

            paisDTO = _mapper.Map<PaisDTO>(pais);

            var respuesta = new ApiRespuesta<PaisDTO>(paisDTO);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("modificarPais/{id}")]
        public async Task<IActionResult> modificarPais(int id,PaisDTO paisDTO)
        {
            var pais = _mapper.Map<Pais>(paisDTO);

            pais.Id = id;

            var resultado =  await _paisServicio.ModificarPais(pais);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminarPais/{id}")]
        public async Task<IActionResult> eliminarPais(int id)
        {
            var resultado = await _paisServicio.EliminarPais(id);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

    }
}
