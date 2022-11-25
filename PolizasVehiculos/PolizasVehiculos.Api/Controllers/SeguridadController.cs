using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolizasVehiculos.Api.ApiRespuesta;
using PolizasVehiculos.Core.DTOs;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Enumeradores;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.Controllers
{
    [Authorize(Roles = nameof(TiposRoles.administrador))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadServicio _seguridadServicio;
        private readonly IMapper _mapper;

        public SeguridadController(ISeguridadServicio seguridadServicio, IMapper mapper)
        {
            _seguridadServicio = seguridadServicio;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registrarUsuario")]
        public async Task<IActionResult> registrarUsuario(SeguridadDTO seguridadDTO)
        {
            var usuario = _mapper.Map<Seguridad>(seguridadDTO);

            await _seguridadServicio.registrarUsuario(usuario);

            seguridadDTO = _mapper.Map<SeguridadDTO>(usuario);

            var respuesta = new ApiRespuesta<SeguridadDTO>(seguridadDTO);

            return Ok(respuesta);
        }
    }
}
