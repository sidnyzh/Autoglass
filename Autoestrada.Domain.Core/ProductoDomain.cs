using Autoestrada.Application.Exceptions;
using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Domain.Interface;
using Autoestrada.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Core
{
    public class ProductoDomain : IProductoDomain
    {
        private readonly IRepository<Producto> _producto;
        private readonly IRepository<Proveedor> _proveedor;

        public ProductoDomain(IRepository<Producto> producto, IRepository<Proveedor> proveedor)
        {
            _producto = producto;
            _proveedor = proveedor;
        }

        public async Task<bool> InsertarProducto(Producto producto)
        {
            bool existeProveedor = await ExisteProveedor(producto.Proveedor);

            if (!existeProveedor) throw new NotFoundException($"No existe un proveedor con código {producto.Proveedor}");

            producto.Estado = "activo";
            return await _producto.InsertAsync(producto);
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            bool proveedor = await ExisteProveedor(producto.Proveedor);

            if (!proveedor)
            {
                throw new NotFoundException($"No existe un proveedor con código {producto.Proveedor}");
            }

            return await _producto.UpdateAsync(producto);
        }

        public async Task<Producto> ObtenerProducto(int codigo)
        {
           var producto = await _producto.GetByIdAsync(codigo);

            if (producto is null) throw new NotFoundException("No existe un producto con este Código");

            return producto;
        }
        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            var productos = await _producto.WhereAsync(x => x.Estado == "activo");

            if (productos is null) throw new NotFoundException("No se encontraron productos");

            return productos;
        }

        public async Task<bool> EliminarProducto(int codigo)
        {
            var producto = await _producto.GetByIdAsync(codigo);

            if (producto is null)
            {
                throw new NotFoundException("No existe un producto con este Código");
            }

            producto.Estado = "inactivo"; 

            return await _producto.UpdateAsync(producto);
            
        }

        private async Task<bool> ExisteProveedor(int codigo)
        {
           return await _proveedor.AnyAsync(x => x.Codigo == codigo);
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosConPaginacion(int cantidad, int pagina)
        {
            var productos = await _producto.GetWithPagination(cantidad, pagina, x => x.Estado == "activo");

            if (productos is null) throw new NotFoundException("No se encontraron productos");

            return productos;
        }
    }
}
