using Autoestrada.Domain.Core;
using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Domain.Interface;
using Autoestrada.Repository.Interface;
using NSubstitute;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using NSubstitute.ExceptionExtensions;
using System.Diagnostics;
using Autoestrada.Application.Exceptions;
using AutoMapper;
using Humanizer;
using Moq;
using NSubstitute.ReturnsExtensions;

namespace Autoestrada.testing
{
    public class ProductoTest
    {
        private readonly IProductoDomain _productoDomain;
        private readonly IRepository<Proveedor> _proveedor = Substitute.For<IRepository<Proveedor>>();
        private readonly IRepository<Producto> _producto = Substitute.For<IRepository<Producto>>();

        public ProductoTest()
        {
            _productoDomain = new ProductoDomain(_producto, _proveedor);
        }


        [Fact]
        public async Task InsertarProductoConProveedorExistenteDebeRetornarTrue()
        {
            //Arrange
            int codigoProducto = 1;
            int codigoProveedor = 1;
            Producto producto = new Producto()
            {
                Id = codigoProducto,
                Proveedor = codigoProveedor,
            };

            Proveedor proveedor = new Proveedor()
            {
                Codigo = codigoProveedor,
            };

            //Act 

             _producto.InsertAsync(producto).Returns<bool>(true);
            var seInsertoProducto = await _productoDomain.InsertarProducto(producto);

            //Assert
            Assert.True(seInsertoProducto);
            
        }

        [Fact]
        public async Task InsertarProductoConProveedorInexistenteDebeRetornarFalse()
        {
            //Arrange
            int codigoProducto = 1;

            int codigoProveedor = 1;
            Producto producto = new Producto()
            {
                Id = codigoProducto,
                Proveedor = codigoProveedor
            };

            //Act 

            Func<Task> act = () => _productoDomain.InsertarProducto(producto);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);

            //Assert
            Assert.Equal("No existe un proveedor con código 1", exception.Message);

        }


        [Fact]
        public async Task ObtenerProductoConCodigoExistenteDebeRetornarTrue()
        {
            //Arrange 
            var codigo = 1;
            var producto = new Producto()
            {
                Id = codigo,
            };

            //Act
            _producto.GetByIdAsync(codigo).Returns(producto); 

            var productoObtenido = await _productoDomain.ObtenerProducto(codigo);

            //Assert
            Assert.True(producto == productoObtenido);

        }

        [Fact]

        public async Task ObtenerProductoConCodigoInexistenteDebeRetornarFalse()
        {

            //Act 
            Producto producto = new Producto()
            {
                Id = 1,
            };
            int codigo = 2;

            //Arrange
            _producto.GetByIdAsync(codigo).ReturnsNull();

            Func<Task> act = () =>  _productoDomain.ObtenerProducto(codigo);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            
            //Assert
            Assert.Equal("No existe un producto con este Código", exception.Message);
            
        }

    }
}
