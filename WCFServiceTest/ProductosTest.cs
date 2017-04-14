using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFServiceTest
{
    class ProductosTest
    {
        private object productosCreado;

        [TestMethod]
        public void TestMethod1()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            proxy.CrearProducto(new ProductosWS.Producto()
            {
                Nombre = "chaufa",
                Descripcion = "especial",
                Precio = 14,
                Descuento = 30,
                Presentacion = "exclusiva",
                CategoriaId = 147,
                Estado = 2

            });

            Assert.AreEqual("chaufa", productosCreado.Nombre);
            Assert.AreEqual("especial", productosCreado.Descripcion);
            Assert.AreEqual(14, productosCreado.Precio);
            Assert.AreEqual(30, productosCreado.Descuento);
            Assert.AreEqual(147, productosCreado.CategoriaId);
            Assert.AreEqual(2, productosCreado.Estado);
        }
        [TestMethod]
        public void ModificarProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            ProductosWS.Producto ProductoModificado = proxy.ModificarProductos( new ProductosWS.Producto()
            {
                Nombre = "chaufa",
                Descripcion = "especial",
                Precio = 14,
                Descuento = 30,
                Presentacion = "exclusiva",
                CategoriaId = 147,
                Estado = 2

            });
            Assert.AreEqual("chaufa", ProductoModificado.Nombre);
            Assert.AreEqual("especial", ProductoModificado.Descripcion);
            Assert.AreEqual(14, ProductoModificado.Precio);
            Assert.AreEqual(30, ProductoModificado.Descuento);
            Assert.AreEqual(147, ProductoModificado.CategoriaId);
            Assert.AreEqual(2, ProductoModificado.Estado);
        }

        [TestMethod]
        public void ObtenerProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            ProductosWS.Producto productoEncontrado = proxy.ObtenerProducto("chaufa");

            Assert.AreEqual("chaufa", productoEncontrado.Nombre);
            Assert.AreEqual("especial", productoEncontrado.Descripcion);
            Assert.AreEqual(14, productoEncontrado.Precio);
            Assert.AreEqual(30, productoEncontrado.Descuento);
            Assert.AreEqual(147, productoEncontrado.CategoriaId);
            Assert.AreEqual(2, productoEncontrado.Estado);
        }

        [TestMethod]
        public void EliminarProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            proxy.EliminarProducto("chaufa");
            ProductosWS.Producto productoEncontrado = proxy.ObtenerProducto("chaufa");
            Assert.IsNull(productoEncontrado);
        }

    }
}
