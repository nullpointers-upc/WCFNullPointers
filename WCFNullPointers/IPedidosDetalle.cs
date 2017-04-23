using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFNullPointers.Dominio;

namespace WCFNullPointers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPedidosDetalle" in both code and config file together.
    [ServiceContract]
    public interface IPedidosDetalle
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PedidosDetalle", ResponseFormat = WebMessageFormat.Json)]
        PedidoDetalle CrearPedidoDetalle(PedidoDetalle pedidoDetalle);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PedidosDetalle/{id}", ResponseFormat = WebMessageFormat.Json)]
        PedidoDetalle ObtenerPedidoDetalle(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "PedidosDetalle", ResponseFormat = WebMessageFormat.Json)]
        PedidoDetalle ModificarPedidoDetalle(PedidoDetalle pedidoDetalle);
        
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "PedidosDetalle/{id}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPedidoDetalle(string id);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PedidosDetalle", ResponseFormat = WebMessageFormat.Json)]
        List<PedidoDetalle> ListarPedidosDetalle();
    }
}
