using Autoestrada.Application.DTO;
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
    public class ProductoApplication : IProductoApplication
    {
        private readonly IProductoDomain _productoDomain;
        private readonly IMapper _mapper;

        public ProductoApplication(IProductoDomain productoDomain, IMapper mapper)
        {
            _productoDomain = productoDomain;
            _mapper = mapper;
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            return await _productoDomain.ActualizarProducto(producto);
        }

        public async Task<bool> InsertarProducto(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);
            return await _productoDomain.InsertarProducto(producto);
        }

        public async Task<Producto> ObtenerProducto(int codigo)
        {
            return await _productoDomain.ObtenerProducto(codigo);
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _productoDomain.ObtenerProductos();
        }

        public async Task<bool> EliminarProducto(int codigo)
        {
            return await _productoDomain.EliminarProducto(codigo);
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosConPaginacion(int cantidad, int pagina)
        {
            return await _productoDomain.ObtenerProductosConPaginacion(cantidad, pagina);
        }
    }
}
