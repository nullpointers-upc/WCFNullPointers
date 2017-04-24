using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class PedidoDetalle
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PedidoId { get; set; }
        [DataMember]
        public int ProductoId { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public decimal Total { get; set; }
    }
}