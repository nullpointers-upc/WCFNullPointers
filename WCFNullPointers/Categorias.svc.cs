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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Categorias" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Categorias.svc or Categorias.svc.cs at the Solution Explorer and start debugging.
    public class Categorias : ICategorias
    {
        private CategoriaDAO categoriaDAO = new CategoriaDAO();
        public string CrearCategoria(Categoria categoria)
        {
            return categoriaDAO.Crear(categoria);
        }
        public string ObtenerCategoria(int id)
        {
            return categoriaDAO.Obtener(id);
        }
        public string ModificarCategoria(Categoria categoriaAModificar)
        {
            return categoriaDAO.Modificar(categoriaAModificar);
        }
        public void EliminarCategoria(int id)
        {
            categoriaDAO.Eliminar(id);
        }

        public List<Categoria> ListarCategoria()
        {
            return categoriaDAO.Listar();
        }
    }
}
