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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PedidosDetalle" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PedidosDetalle.svc or PedidosDetalle.svc.cs at the Solution Explorer and start debugging.
    public class PedidosDetalle : IPedidosDetalle
    {
        private PedidoDetalleDAO pedidoDetalleDAO = new PedidoDetalleDAO();
        public PedidoDetalle CrearPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            return pedidoDetalleDAO.Crear(pedidoDetalle);
        }

        public PedidoDetalle ObtenerPedidoDetalle(string id)
        {
            return pedidoDetalleDAO.Obtener(int.Parse(id));
        }

        public PedidoDetalle ModificarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            return pedidoDetalleDAO.Modificar(pedidoDetalle);
        }

        public void EliminarPedidoDetalle(string id)
        {
            pedidoDetalleDAO.Eliminar(int.Parse(id));
        }

        public List<PedidoDetalle> ListarPedidosDetalle()
        {
            return pedidoDetalleDAO.Listar();
        }
    }
}
