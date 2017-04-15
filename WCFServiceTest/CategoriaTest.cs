﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Web.Script.Serialization;

namespace WCFServiceTest
{
    class CategoriaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            string categoriaX = proxy.CrearCategoria(new CategoriasWS.Categoria()
            {
                Nombre = "Menu",
                Estado = 1,
            });
            JavaScriptSerializer categoriaZ = new JavaScriptSerializer();
            CategoriaWS.Categoria categoria = (CategoriaWS.Categoria)CategoriaZ.Deserialize<CategoriaWS.Categoria>(categoriaX);
            Assert.AreEqual("Menu", categoria.Nombre);
            Assert.AreEqual(1, categoria.Estado);
        }
        
        [TestMethod]
        public void ModificarCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            CategoriasWS.Categoria CategoriaModificado = proxy.ModificarCategoria(new UsuariosWS.Usuario()
            {
                Nombre = "Menu",
                Estado = 1,

            });
            Assert.AreEqual("Menu", categoriasCreado.Nombre);
            Assert.AreEqual(1, categoriasCreado.Estado);
        }

        [TestMethod]
        public void ObtenerCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            CategoriasWS.Categoria categoriaEncontrado = proxy.ObtenerCategoria("Menu");

            Assert.AreEqual("Menu", categoriaEncontrado.Nombre);
            Assert.AreEqual(1, categoriaEncontrado.Estado);
        }

        [TestMethod]
        public void EliminarCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            proxy.EliminarCategoria("Menu");
            CategoriasWS.Categoria categoriaEncontrado = proxy.ObtenerCategoria("Menu");
            Assert.IsNull(categoriaEncontrado);
        }
    }
}
