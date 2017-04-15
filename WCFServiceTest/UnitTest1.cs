using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
<<<<<<< HEAD
using System.Web.Script.Serialization;
=======
using System.ServiceModel;
>>>>>>> origin/master

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        private object usuarioCreado;

        [TestMethod]
        public void CrearUsuarioTest1()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
<<<<<<< HEAD
            string usuarioX = proxy.CrearUsuario(new UsuariosWS.Usuario()
            {
                Codigo = "jperez",
                Contrasena = "juanito",
                Dni = "555666777",
                Nombre = "Juan",
                Apellidos = "Perez Perez",
                Telefono = "12345"
            });
            JavaScriptSerializer usuarioZ = new JavaScriptSerializer();
            UsuariosWS.Usuario usuario = (UsuariosWS.Usuario)usuarioZ.Deserialize<UsuariosWS.Usuario>(usuarioX);
            Assert.AreEqual("jperez", usuario.Codigo);
            Assert.AreEqual("juanito", usuario.Contrasena);
            Assert.AreEqual("555666777", usuario.Dni);
            Assert.AreEqual("Juan", usuario.Nombre);
            Assert.AreEqual("Perez Perez", usuario.Apellidos);
            Assert.AreEqual("12345", usuario.Telefono);
=======
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
>>>>>>> origin/master
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
