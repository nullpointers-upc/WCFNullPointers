﻿using System;
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
        public void Test1CrearPedidoDetalle()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            PedidoDetalle pedidoDetalle = new PedidoDetalle()
            {
                PedidoId = 1,
                ProductoId = 2,
                Cantidad = 2,
                Precio = 30,
                Total = 60
            };
            string postdata = js.Serialize(pedidoDetalle);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            PedidoDetalle pedidoDetalleCreado = js.Deserialize<PedidoDetalle>(tramaJson);
            
            Assert.AreEqual(1, pedidoDetalle.PedidoId);
            Assert.AreEqual(2, pedidoDetalle.ProductoId);
            Assert.AreEqual(2, pedidoDetalle.Cantidad);
            Assert.AreEqual(30, pedidoDetalle.Precio);
            Assert.AreEqual(60, pedidoDetalle.Total);
        }
        
        [TestMethod]
        public void Test2ObtenerPedidoDetalle()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle/1");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            PedidoDetalle pedidoDetalle = js.Deserialize<PedidoDetalle>(tramaJson);
            
            Assert.AreEqual(1, pedidoDetalle.PedidoId);
            Assert.AreEqual(1, pedidoDetalle.ProductoId);
            Assert.AreEqual(3, pedidoDetalle.Cantidad);
            Assert.AreEqual(300, pedidoDetalle.Precio);
            Assert.AreEqual(900, pedidoDetalle.Total);
        }
        
        [TestMethod]
        public void Test3ModificarPedidoDetalle()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            PedidoDetalle pedidoDetalle = new PedidoDetalle()
            {
                Id = 2,
                PedidoId = 1,
                ProductoId = 2,
                Cantidad = 2,
                Precio = 40,
                Total = 80
            };
            string postdata = js.Serialize(pedidoDetalle);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle");
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            PedidoDetalle pedidoDetalleCreado = js.Deserialize<PedidoDetalle>(tramaJson);
            
            Assert.AreEqual(1, pedidoDetalle.PedidoId);
            Assert.AreEqual(2, pedidoDetalle.ProductoId);
            Assert.AreEqual(2, pedidoDetalle.Cantidad);
            Assert.AreEqual(40, pedidoDetalle.Precio);
            Assert.AreEqual(80, pedidoDetalle.Total);
        }
        
        [TestMethod]
        public void Test4EliminarPedidoDetalle()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle/2");
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle/2");
            request2.Method = "GET";
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader = new StreamReader(response2.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            PedidoDetalle pedidoDetalle = js.Deserialize<PedidoDetalle>(tramaJson);
            Assert.IsNull(pedidoDetalle);
        }
        
        [TestMethod]
        public void Test5ListarPedidosDetalle()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:3401/PedidosDetalle.svc/PedidosDetalle");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PedidoDetalle> pedidosDetalle = js.Deserialize<List<PedidoDetalle>>(tramaJson);
            Assert.AreEqual(2, pedidosDetalle.Count);
        }
    }
}
