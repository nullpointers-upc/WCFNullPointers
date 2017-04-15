using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers.Dominio;

namespace WCFNullPointers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductos" in both code and config file together.
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        string CrearProducto(Producto productos);

        [OperationContract]
        string ObtenerProducto(int id);

        [OperationContract]
        string ModificarProducto(Producto productos);

        [OperationContract]
        void EliminarProducto(int id);

        [OperationContract]
        string ListarProductos();
    }
}
