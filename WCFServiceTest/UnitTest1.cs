﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.ServiceModel;

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            string usuarioX = proxy.CrearUsuario(new UsuariosWS.Usuario()
            {
                Codigo = "3333",
                Contrasena = "cha123456",
                Dni = "12345678",
                Nombre = "Santiago",
                Apellidos = "Saavedra",
                Telefono = "123456"
            });
            JavaScriptSerializer usuarioZ = new JavaScriptSerializer();
            UsuariosWS.Usuario usuario = (UsuariosWS.Usuario)usuarioZ.Deserialize<UsuariosWS.Usuario>(usuarioX);

            Assert.AreEqual("222222", usuario.Codigo);
            Assert.AreEqual("cha123456", usuario.Contrasena);
            Assert.AreEqual("12345678", usuario.Dni);
            Assert.AreEqual("Santiago", usuario.Nombre);
            Assert.AreEqual("Saavedra", usuario.Apellidos);
            Assert.AreEqual("123456", usuario.Telefono);
        }

        [TestMethod]
        public void ModificarUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            string usuarioX = proxy.ModificarUsuario(new UsuariosWS.Usuario()
            {
                Id = 10,
                Codigo = "222222",
                Contrasena = "cha123456",
                Dni = "12345678",
                Nombre = "Santiago",
                Apellidos = "Saavedra",
                Telefono = "1234567"
            });
            JavaScriptSerializer usuarioZ = new JavaScriptSerializer();
            UsuariosWS.Usuario usuario = (UsuariosWS.Usuario)usuarioZ.Deserialize<UsuariosWS.Usuario>(usuarioX);

            Assert.AreEqual("222222", usuario.Codigo);
            Assert.AreEqual("cha123456", usuario.Contrasena);
            Assert.AreEqual("12345678", usuario.Dni);
            Assert.AreEqual("Santiago", usuario.Nombre);
            Assert.AreEqual("Saavedra", usuario.Apellidos);
            Assert.AreEqual("1234567", usuario.Telefono);
        }

        [TestMethod]
        public void ObtenerUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            string usuarioX = proxy.ObtenerUsuario(2);
            JavaScriptSerializer usuarioZ = new JavaScriptSerializer();
            UsuariosWS.Usuario usuario = (UsuariosWS.Usuario)usuarioZ.Deserialize<UsuariosWS.Usuario>(usuarioX);
            
            Assert.AreEqual(2, usuario.Id);
            Assert.AreEqual("222222", usuario.Codigo);
            Assert.AreEqual("cha123456", usuario.Contrasena);
            Assert.AreEqual("12345678", usuario.Dni);
            Assert.AreEqual("Santiago", usuario.Nombre);
            Assert.AreEqual("Saavedra", usuario.Apellidos);
            Assert.AreEqual("1234567", usuario.Telefono);
        }

        [TestMethod]
        public void EliminarUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            proxy.EliminarUsuario(2);
            string usuarioX = proxy.ObtenerUsuario(2);
            
            Assert.IsNull(usuarioX);
        }
    }
}