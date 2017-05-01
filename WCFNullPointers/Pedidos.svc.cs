using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFNullPointers;
using WCFNullPointers.Dominio;
using WCFNullPointers.Persistencia;

namespace WCFNullPointers
{
    public class Pedidos : IPedidos
    {
        private PedidoDAO pedidoDAO = new PedidoDAO();
        public Pedido CrearPedido(Pedido pedido)
        {
             return pedidoDAO.Crear(pedido);
        }

        public void EliminarPedido(string id)
        {
            pedidoDAO.Eliminar(int.Parse(id));
        }

        public List<Pedido> ListarPedidos()
        {
            return pedidoDAO.Listar();
        }

        public Pedido ObtenerPedido(string id)
        {
            return pedidoDAO.Obtener(int.Parse(id));
        }
        public Pedido ActualizarEstadoPedido(string id, string estado)
        {
            return pedidoDAO.ActualizarEstado(int.Parse(id), int.Parse(estado));
        }
    }
}
