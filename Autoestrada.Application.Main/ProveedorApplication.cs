using Autoestrada.Application.Interface;
using Autoestrada.Domain.Core;
using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Domain.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Application.Main
{
    public class ProveedorApplication : IProveedorApplication
    {
        private readonly IProveedorDomain _proveedorDomain;
        private readonly IMapper _mapper;

        public ProveedorApplication(IProveedorDomain proveedorDomain, IMapper mapper)
        {
            _proveedorDomain = proveedorDomain;
            _mapper = mapper;
        }

        public async Task<bool> ActualizarProveedor(Proveedor proveedor)
        {
            return await _proveedorDomain.ActualizarProveedor(proveedor);
        }

        public async Task<bool> InsertarProveedor(Proveedor proveedor)
        {
            return await _proveedorDomain.InsertarProveedor(proveedor);
        }

        public async Task<Proveedor> ObtenerProveedor(int id)
        {
            return await _proveedorDomain.ObtenerProveedor(id);
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            return await _proveedorDomain.ObtenerProveedores();
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedoresConPaginacion(int cantidad, int pagina)
        {
            return await _proveedorDomain.ObtenerProveedoresConPaginacion(cantidad, pagina);
        }

        public async Task<bool> EliminarProveedor(int codigo)
        {
            return await _proveedorDomain.EliminarProveedor(codigo);
        }
    }
}
