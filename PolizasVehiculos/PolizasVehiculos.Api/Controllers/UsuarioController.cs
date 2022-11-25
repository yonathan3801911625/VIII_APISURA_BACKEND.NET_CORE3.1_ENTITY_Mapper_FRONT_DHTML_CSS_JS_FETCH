using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolizasVehiculos.Api.ApiRespuesta;
using PolizasVehiculos.Core.DTOs;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServicio usuarioServicio,IMapper mapper) 
        {
            _usuarioServicio = usuarioServicio;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos los usuarios
        /// </summary>
        /// <returns></returns>
        //[HttpGet(Name = nameof(obtenerPaises)]
        //[ProducesResponseType((int)HttpStatusCode.OK,Type = typeof())]
        [HttpGet]
        [Route("obtenerUsuarios")]
        public IActionResult obtenerUsuarios()
        {
            var usuarios = _usuarioServicio.ObtenerUsuarios();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            var respuesta = new ApiRespuesta<IEnumerable<UsuarioDTO>>(usuariosDTO);
            return Ok(respuesta);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("obtenerUsuario/{id}")]
        public async Task<IActionResult> obtenerUsuario(int id)
        {
            var usuario = await _usuarioServicio.ObtenerUsuario(id);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            var respuesta = new ApiRespuesta<UsuarioDTO>(usuarioDTO);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("insertarUsuario")]
        public async Task<IActionResult> insertarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            await _usuarioServicio.InsertarUsuario(usuario);

            usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            var respuesta = new ApiRespuesta<UsuarioDTO>(usuarioDTO);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("modificarUsuario/{id}")]
        public async Task<IActionResult> modificarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            usuario.Id = id;

            var resultado = await _usuarioServicio.ModificarUsuario(usuario);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminarUsuario/{id}")]
        public async Task<IActionResult> eliminarUsuario(int id)
        {
            var resultado = await _usuarioServicio.EliminarUsuario(id);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("loginParaAutenticar/{login}/{contraseña}")]
        public async Task<IActionResult> loginParaAutenticar(string login,string contraseña)
        {
            var usuario = _mapper.Map<Usuario>(new UsuarioDTO() { LoginUsuario = login,PasswordUsuario = contraseña });
            var usuarioRespuesta = await _usuarioServicio.obtenerLogin(usuario);
            var usuarioDTO = usuarioRespuesta != null ?  _mapper.Map<UsuarioDTO>(usuario) : null;
            var respuesta = new ApiRespuesta<UsuarioDTO>(usuarioDTO);
            return Ok(respuesta);
        }
    }
}
