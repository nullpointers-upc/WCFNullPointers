using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WCFServiceTest
{
    [TestClass]
    public class PedidoDetalleTest
    {
        [TestMethod]
        public void TestObtenerPedidoDetalle()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle/1");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            PedidoDetalle pedidoDetalle = js.Deserialize<PedidoDetalle>(tramaJson);
            Assert.AreEqual(3, pedidoDetalle.Cantidad);
/*            Assert.AreEqual("CARLOS VALENZUELA", trabajadorObtenido.Nombre);
            Assert.AreEqual("7952525", trabajadorObtenido.Telefono);
            Assert.AreEqual(true, trabajadorObtenido.Sexo);
            Assert.AreEqual(1500, trabajadorObtenido.Sueldo);*/
        }
    }
}
