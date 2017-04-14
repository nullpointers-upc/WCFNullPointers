using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFNullPointers
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProductos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        string CrearProductos(Productos productosACrear);

        [OperationContract]
        string ObtenerProductos(int id);

        [OperationContract]
        string ModificarProductos(Productos productosAModificar);

        [OperationContract]
        void EliminarProductos(int id);

        [OperationContract]
        List<Productos> ListarProductos();
    }
}

