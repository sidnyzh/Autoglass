using Autoestrada.Application.DTO;
using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Application.Interface
{
    public interface IProductoApplication
    {
        Task<bool> InsertarProducto(ProductoDTO productoDTO);
        Task<bool> ActualizarProducto(Producto producto);
        Task<Producto> ObtenerProducto(int codigo);
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<IEnumerable<Producto>> ObtenerProductosConPaginacion(int cantidad, int pagina);
        Task<bool> EliminarProducto(int id);
    }
}
