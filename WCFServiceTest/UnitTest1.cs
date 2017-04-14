using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        private object usuarioCreado;

        [TestMethod]
        public void TestMethod1()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            proxy.CrearUsuario(new UsuariosWS.Usuario()
            {
                Codigo = "222222",
                Contrasena = "cha123456",
                Dni = "12345678",
                Nombre = "Santiago",
                Apellidos = "Saavedra",
                Telefono = "1234567"

            });

            Assert.AreEqual("222222", usuarioCreado.Codigo);
            Assert.AreEqual("cha123456", usuarioCreado.contrasena);
            Assert.AreEqual("12345678", usuarioCreado.dni);
            Assert.AreEqual("Santiago", usuarioCreado.nombre);
            Assert.AreEqual("Saavedra", usuarioCreado.apellidos);
            Assert.AreEqual("1234567", usuarioCreado.telefono);
        }
        [TestMethod]
        public void ModificarUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            UsuariosWS.Usuario UsuarioModificado = proxy.ModificarUsuario(new UsuariosWS.Usuario()
            {
                Codigo = "222222",
                Contrasena = "cha123456",
                Dni = "12345678",
                Nombre = "Santiago",
                Apellidos = "Saavedra",
                Telefono = "1234567"

            });

            Assert.AreEqual("222222", UsuarioModificado.Codigo);
            Assert.AreEqual("cha123456", UsuarioModificado.Contrasena);
            Assert.AreEqual("12345678", UsuarioModificado.Dni);
            Assert.AreEqual("Santiago", UsuarioModificado.Nombre);
            Assert.AreEqual("Saavedra", UsuarioModificado.Apellidos);
            Assert.AreEqual("1234567", UsuarioModificado.Telefono);
        }

        [TestMethod]
        public void ObtenerUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            UsuariosWS.Usuario usuarioEncontrado = proxy.ObtenerUsuario("222222");

            Assert.AreEqual("222222", usuarioEncontrado.Codigo);
            Assert.AreEqual("cha123456", usuarioEncontrado.Contrasena);
            Assert.AreEqual("12345678", usuarioEncontrado.Dni);
            Assert.AreEqual("Santiago", usuarioEncontrado.Nombre);
            Assert.AreEqual("Saavedra", usuarioEncontrado.Apellidos);
            Assert.AreEqual("1234567", usuarioEncontrado.Telefono);
        }

        [TestMethod]
        public void EliminarUsuarioTest()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            proxy.EliminarUsuario("222222");
            UsuariosWS.Usuario usuarioEncontrado = proxy.ObtenerUsuario("222222");
            Assert.IsNull(usuarioEncontrado);
        }

    }
}
