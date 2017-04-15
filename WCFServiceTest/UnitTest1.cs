using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearUsuarioTest1()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
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
        }
    }
}
