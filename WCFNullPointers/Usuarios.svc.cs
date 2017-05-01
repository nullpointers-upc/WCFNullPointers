using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers.Dominio;
using WCFNullPointers.Errores;
using WCFNullPointers.Persistencia;

namespace WCFNullPointers
{
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
            string login = usuarioDAO.Login(codigo, contrasena);           
            if (login == null)
            {
                throw new FaultException<LoginException>(
                    new LoginException()
                    {
                        Codigo = "902",
                        Descripcion = "Usuario no existe o contraseña incorrecta"
                    },
                    new FaultReason("Error de autenticación"));
            }
            return login;
        }
        
        public string ModificarUsuario(Usuario usuarioAModificar)
        {
            return usuarioDAO.Modificar(usuarioAModificar);
        }
        
        public void EliminarUsuario(int id)
        {
            usuarioDAO.Eliminar(id);
        }

        public string ListarUsuarios()
        {
            return usuarioDAO.Listar();
        }
    }
}
