using Autoestrada.Application.Exceptions;
using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Domain.Interface;
using Autoestrada.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Core
{
    public class ProveedorDomain : IProveedorDomain
    {
        private readonly IRepository<Proveedor> _proveedor;

        public ProveedorDomain(IRepository<Proveedor> proveedor)
        {
            _proveedor = proveedor;
        }

        public async Task<bool> ActualizarProveedor(Proveedor proveedor)
        {
            bool existeProveedor = await ExisteProveedor(proveedor.Codigo);

            if (!existeProveedor) throw new BadRequestException("El proveedor que intentas actualizar no existe");

            return await _proveedor.UpdateAsync(proveedor);
        }

        public async Task<bool> EliminarProveedor(int codigo)
        {
            bool existeProveedor = await ExisteProveedor(codigo);

            if (!existeProveedor) throw new NotFoundException("El proveedor que intentas eliminar no existe");
            
            return await _proveedor.DeleteAsync(codigo);
        }

        public async Task<bool> InsertarProveedor(Proveedor proveedor)
        {
            bool existeProveedor = await ExisteProveedor(proveedor.Codigo);

            if (existeProveedor) throw new BadRequestException("Ya existe un proveedor con ese código");

            return await _proveedor.InsertAsync(proveedor);
        }

        public async Task<Proveedor> ObtenerProveedor(int codigo)
        {
            var proveedores = await _proveedor.GetByIdAsync(codigo);

            if (proveedores is null) throw new NotFoundException("No se encontró el proveedor con ese código");

            return proveedores;
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            var proveedores = await _proveedor.GetAllAsync();

            if (proveedores is null) throw new NotFoundException("No se encontraron proveedores");

            return proveedores;
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedoresConPaginacion(int cantidad, int pagina)
        {
            var proveedores = await _proveedor.GetWithPagination(cantidad, pagina);

            if (proveedores is null) throw new NotFoundException("No se encontraron proveedores");

            return proveedores;
        }

        private async Task<bool> ExisteProveedor(int Codigo)
        {
            return await _proveedor.AnyAsync(x => x.Codigo == Codigo);
        }
    }
}
