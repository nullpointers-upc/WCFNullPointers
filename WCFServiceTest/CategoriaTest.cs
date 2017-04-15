using System;
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
            CategoriasWS.Categoria categoria = (CategoriasWS.Categoria)categoriaZ.Deserialize<CategoriasWS.Categoria>(categoriaX);

            Assert.AreEqual("Menu", categoria.Nombre);
            Assert.AreEqual(1, categoria.Estado);
        }
        
        [TestMethod]
        public void ModificarCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            string CategoriaX = proxy.ModificarCategoria(new CategoriasWS.Categoria()
            {
                Nombre = "Menu",
                Estado = 1,

            });
            JavaScriptSerializer categoriaZ = new JavaScriptSerializer();
            CategoriasWS.Categoria categoria = (CategoriasWS.Categoria)categoriaZ.Deserialize<CategoriasWS.Categoria>(CategoriaX);

            Assert.AreEqual("Menu", categoria.Nombre);
            Assert.AreEqual(1, categoria.Estado);
        }

        [TestMethod]
        public void ObtenerCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            string categoriaX = proxy.ObtenerCategoria(1);
            JavaScriptSerializer categoriaZ = new JavaScriptSerializer();
            CategoriasWS.Categoria Categoria = (CategoriasWS.Categoria)categoriaZ.Deserialize<CategoriasWS.Categoria>(categoriaX);

            Assert.AreEqual(3, Categoria.Id);
            Assert.AreEqual("Menu", Categoria.Nombre);
            Assert.AreEqual(1, Categoria.Estado);
        }

        [TestMethod]
        public void EliminarCategoriaTest()
        {
            CategoriasWS.CategoriasClient proxy = new CategoriasWS.CategoriasClient();
            proxy.EliminarCategoria(3);
            string CategoriaX = proxy.ObtenerCategoria(3);

            Assert.IsNull(CategoriaX);
        }
    }
}
