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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        private readonly IMapper _mapper;

        public ProductoController(IProductoServicio productoServicio, IMapper mapper) {
            _productoServicio = productoServicio;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos los paises
        /// </summary>
        /// <returns></returns>
        //[HttpGet(Name = nameof(obtenerPaises)]
        //[ProducesResponseType((int)HttpStatusCode.OK,Type = typeof())]
        [HttpGet]
        [Route("obtenerProductos")]
        public IActionResult obtenerProductos()
        {
            var productos = _productoServicio.ObtenerProductos();
            var productosDTO = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            var respuesta = new ApiRespuesta<IEnumerable<ProductoDTO>>(productosDTO);
            return Ok(respuesta);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("obtenerProducto/{id}")]
        public async Task<IActionResult> obtenerProducto(int id)
        {
            var producto = await _productoServicio.ObtenerProducto(id);
            var productoDTO = _mapper.Map<ProductoDTO>(producto);
            var respuesta = new ApiRespuesta<ProductoDTO>(productoDTO);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("insertarProducto")]
        public async Task<IActionResult> insertarProducto(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);

            await _productoServicio.InsertarProducto(producto);

            productoDTO = _mapper.Map<ProductoDTO>(producto);

            var respuesta = new ApiRespuesta<ProductoDTO>(productoDTO);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("modificarProducto/{id}")]
        public async Task<IActionResult> modificarProducto(int id, ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);

            producto.Id = id;

            var resultado = await _productoServicio.ModificarProducto(producto);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminarProducto/{id}")]
        public async Task<IActionResult> eliminarProducto(int id)
        {
            var resultado = await _productoServicio.EliminarProducto(id);

            var respuesta = new ApiRespuesta<bool>(resultado);

            return Ok(respuesta);
        }


    }
}
