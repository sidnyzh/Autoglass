using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Interface
{
    public interface IProductoDomain
    {

        Task<bool> InsertarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int codigo);
        Task<Producto> ObtenerProducto(int codigo); 
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<IEnumerable<Producto>> ObtenerProductosConPaginacion(int cantidad, int pagina);

    }
}
