using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Interface
{
    public interface IProveedorDomain
    {

        Task<bool> InsertarProveedor(Proveedor proveedor);
        Task<bool> ActualizarProveedor(Proveedor proveedor);
        Task<bool> EliminarProveedor(int codigo);
        Task<Proveedor> ObtenerProveedor(int codigo);
        Task<IEnumerable<Proveedor>> ObtenerProveedoresConPaginacion(int cantidad, int pagina);
        Task<IEnumerable<Proveedor>> ObtenerProveedores();
    }
}
