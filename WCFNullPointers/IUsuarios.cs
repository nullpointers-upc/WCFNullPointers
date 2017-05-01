using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers.Dominio;
using WCFNullPointers.Errores;

namespace WCFNullPointers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarios" in both code and config file together.
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        string CrearUsuario(Usuario usuarioACrear);

        [OperationContract]
        string ObtenerUsuario(int id);

        [FaultContract(typeof(LoginException))]
        [OperationContract]
        string LoginUsuario(string codigo, string contrasena);

        [OperationContract]
        string ModificarUsuario(Usuario usuarioAModificar);

        [OperationContract]
        void EliminarUsuario(int id);
        
        [OperationContract]
        string ListarUsuarios();        
    }
}
