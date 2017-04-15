﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.ServiceModel;

namespace WCFServiceTest
{
    [TestClass]
    class ProductosTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            string productoX = proxy.CrearProducto(new ProductosWS.Producto()
            {
                Nombre = "chaufa",
                Descripcion = "especial",
                Precio = 14,
                Descuento = 30,
                Presentacion = "exclusiva",
                CategoriaId = 147,
                Estado = 2
            });
            JavaScriptSerializer productoZ = new JavaScriptSerializer();
            ProductosWS.Producto producto = (ProductosWS.Producto) productoZ.Deserialize<ProductosWS.Producto>(productoX);

            Assert.AreEqual("chaufa", producto.Nombre);
            Assert.AreEqual("especial", producto.Descripcion);
            Assert.AreEqual(14, producto.Precio);
            Assert.AreEqual(30, producto.Descuento);
            Assert.AreEqual("exclusiva", producto.Presentacion);
            Assert.AreEqual(147, producto.CategoriaId);
            Assert.AreEqual(2, producto.Estado);
        }
        
        [TestMethod]
        public void ModificarProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            string productoX = proxy.ModificarProducto(new ProductosWS.Producto()
            {
                Id = 1,
                Nombre = "chaufa",
                Descripcion = "especial",
                Precio = 14,
                Descuento = 30,
                Presentacion = "exclusiva",
                CategoriaId = 147,
                Estado = 2
            });
            JavaScriptSerializer productoZ = new JavaScriptSerializer();
            ProductosWS.Producto producto = (ProductosWS.Producto) productoZ.Deserialize<ProductosWS.Producto>(productoX);

            Assert.AreEqual("chaufa", producto.Nombre);
            Assert.AreEqual("especial", producto.Descripcion);
            Assert.AreEqual(14, producto.Precio);
            Assert.AreEqual(30, producto.Descuento);
            Assert.AreEqual("exclusiva", producto.Presentacion);
            Assert.AreEqual(147, producto.CategoriaId);
            Assert.AreEqual(2, producto.Estado);
        }

        [TestMethod]
        public void ObtenerProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            string productoX = proxy.ObtenerProducto(1);
            JavaScriptSerializer productoZ = new JavaScriptSerializer();
            ProductosWS.Producto producto = (ProductosWS.Producto) productoZ.Deserialize<ProductosWS.Producto>(productoX);
            
            Assert.AreEqual(1, producto.Id);
            Assert.AreEqual("chaufa", producto.Nombre);
            Assert.AreEqual("especial", producto.Descripcion);
            Assert.AreEqual(14, producto.Precio);
            Assert.AreEqual(30, producto.Descuento);
            Assert.AreEqual("exclusiva", producto.Presentacion);
            Assert.AreEqual(147, producto.CategoriaId);
            Assert.AreEqual(2, producto.Estado);
        }

        [TestMethod]
        public void EliminarProductoTest()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            proxy.EliminarProducto(1);
            string productoX = proxy.ObtenerProducto(1);
            
            Assert.IsNull(productoX);
        }
    }
}
