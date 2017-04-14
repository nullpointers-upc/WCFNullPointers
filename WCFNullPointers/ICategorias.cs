using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers.Dominio;

namespace WCFNullPointers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICategorias" in both code and config file together.
    [ServiceContract]
    public interface ICategorias
    {
        [OperationContract]
        string CrearCategoria(Categoria categoria);
    }
}
