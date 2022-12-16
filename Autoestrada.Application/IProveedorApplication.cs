using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Application.Interface
{
    public interface IProveedorApplication
    {
        Task<bool> InsertarProveedor(Proveedor proveedor);
        Task<bool> ActualizarProveedor(Proveedor proveedor);
        Task<Proveedor> ObtenerProveedor(int id);
        Task<IEnumerable<Proveedor>> ObtenerProveedores();
        Task<IEnumerable<Proveedor>> ObtenerProveedoresConPaginacion(int cantidad, int pagina);
        Task<bool> EliminarProveedor(int codigo);
    }
}
