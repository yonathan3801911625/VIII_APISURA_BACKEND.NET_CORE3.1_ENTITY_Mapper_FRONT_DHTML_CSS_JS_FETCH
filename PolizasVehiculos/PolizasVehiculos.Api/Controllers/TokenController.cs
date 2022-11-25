using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISeguridadServicio _seguridadServicio;
        public TokenController(IConfiguration configuration, ISeguridadServicio seguridadServicio) 
        {
            _configuration = configuration;
            _seguridadServicio = seguridadServicio;
        }

        /// <summary>
        /// Autenticacion por Token
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Autenticacion")]
        public async Task<IActionResult> Autenticacion(UsuarioLogin usuarioLogin) 
        {
            var validacion = await EsUsuarioValido(usuarioLogin);
            if (validacion.Item1) 
            {
                var token = GenerarToken(validacion.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool,Seguridad)> EsUsuarioValido(UsuarioLogin usuarioLogin)
        {
            var usuario = await _seguridadServicio.obtenerLoginParaCredenciales(usuarioLogin);
            return (usuario != null, usuario);
        }

        private string GenerarToken(Seguridad seguridad) 
        {
            //header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

            var signingCredentials = new SigningCredentials(_symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,seguridad.NombreUsuario),
                new Claim("Usuario",seguridad.Usuario),
                new Claim(ClaimTypes.Role,seguridad.Rol.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audiencie"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header,payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
