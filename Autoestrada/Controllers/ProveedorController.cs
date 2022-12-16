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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorApplication _proveedorApplication;

        public ProveedorController(IProveedorApplication proveedorApplication)
        {
            _proveedorApplication = proveedorApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProveedor([FromBody] Proveedor proveedor)
        {
            return Ok(await _proveedorApplication.InsertarProveedor(proveedor));
        }

        [HttpPut]

        public async Task<IActionResult> ActualizarProveedor([FromBody] Proveedor proveedor)
        {
            return Ok(await _proveedorApplication.ActualizarProveedor(proveedor));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProveedor(int id)
        {
            return Ok(await _proveedorApplication.ObtenerProveedor(id));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProveedores()
        {
            return Ok(await _proveedorApplication.ObtenerProveedores());
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProveedoresConPaginacion(int cantidad, int pagina)
        {
            return Ok(await _proveedorApplication.ObtenerProveedoresConPaginacion(cantidad, pagina));
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProveedor(int id)
        {
            return Ok(await _proveedorApplication.EliminarProveedor(id));
        }


    }
}
