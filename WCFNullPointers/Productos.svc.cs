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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Productos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Productos.svc or Productos.svc.cs at the Solution Explorer and start debugging.
    public class Productos : IProductos
    {
        private ProductoDAO productoDAO = new ProductoDAO();
        public string CrearProducto(Producto producto)
        {
            return productoDAO.Crear(producto);
        }
        
        public string ObtenerProducto(int id)
        {
            return productoDAO.Obtener(id);
        }
         
        public string ModificarProducto(Producto producto)
        {
            return productoDAO.Modificar(producto);
        }
        
        public void EliminarProducto(int id)
        {
            productoDAO.Eliminar(id);
        }
        
        public string ListarProductos()
        {
            return productoDAO.Listar();
        }
    }
}
