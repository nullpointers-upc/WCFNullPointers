﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFNullPointers.Dominio;

namespace WCFNullPointers
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPedidos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="Pedidos", ResponseFormat=WebMessageFormat.Json)]

        Pedido CrearPedido(Pedido pedidos);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Pedidos/{id}", ResponseFormat = WebMessageFormat.Json)]
        Pedido ObtenerPedido(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Pedidos", ResponseFormat = WebMessageFormat.Json)]
        Pedido ModificarPedido(Pedido pedidos);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Pedidos/{id}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPedido(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Pedidos", ResponseFormat = WebMessageFormat.Json)]
        List<Pedido> ListarPedidos();
    }
}