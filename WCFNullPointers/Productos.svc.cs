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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Productos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Productos.svc o Productos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Productos : IProductos
    {osDAO = new ProductosDAO();
        public string CrearProducto
        private ProductosDAO products(Productos ProductosACrear)
        {
            return productosDAO.Crear(ProductosACrear);
        }

        public string CrearProductos(Productos productosACrear)
        {
            throw new NotImplementedException();
        }

        public string ObtenerProductos(int id)
        {
            throw new NotImplementedException();
        }

        public string ModificarProductos(Productos productosAModificar)
        {
            throw new NotImplementedException();
        }

        public void EliminarProductos(int id)
        {
            throw new NotImplementedException();
        }

        public List<Productos> ListarProductos()
        {
            throw new NotImplementedException();
        }
    }
}
