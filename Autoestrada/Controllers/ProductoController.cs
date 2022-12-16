using Autoestrada.Application.DTO;
using Autoestrada.Application.Interface;
using Autoestrada.Domain.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoestrada.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoApplication _productoApplication;

        public ProductoController(IProductoApplication productoApplication)
        {
            _productoApplication = productoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProducto([FromBody] ProductoDTO productoDTO)
        {
            return Ok(await _productoApplication.InsertarProducto(productoDTO));
        }

        [HttpPut]

        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            return Ok(await _productoApplication.ActualizarProducto(producto));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProducto(int codigo)
        {
            return Ok(await _productoApplication.ObtenerProducto(codigo));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            return Ok(await _productoApplication.ObtenerProductos());
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductosConPaginacion(int cantidad, int pagina)
        {
            return Ok(await _productoApplication.ObtenerProductosConPaginacion(cantidad, pagina));
        }

        [HttpDelete]

        public async Task<IActionResult> EliminarProducto(int codigo)
        {
            return Ok(await _productoApplication.EliminarProducto(codigo));
        }
    }
}
