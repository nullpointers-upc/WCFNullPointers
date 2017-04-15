using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers.Dominio;
using WCFNullPointers.Persistencia;

namespace WCFNullPointers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuarios" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuarios.svc or Usuarios.svc.cs at the Solution Explorer and start debugging.
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        public string CrearUsuario(Usuario usuarioACrear)
        {
            return usuarioDAO.Crear(usuarioACrear);
        }

        public string ObtenerUsuario(int id)
        {
            return usuarioDAO.Obtener(id);
        }

        public string LoginUsuario(string codigo, string contrasena)
        {
            return usuarioDAO.Login(codigo, contrasena);
        }
        public string ModificarUsuario(Usuario usuarioAModificar)
        {
            return usuarioDAO.Modificar(usuarioAModificar);
        }
        public void EliminarUsuario(int id)

        {
            usuarioDAO.Eliminar(id);
        }

        public List<Usuario> ListarUsuarios()
        {
            return usuarioDAO.Listar();
        }
    
    }
}
