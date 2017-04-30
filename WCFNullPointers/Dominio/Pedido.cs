using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime  Fecha  { get; set; }

        [DataMember]
        public int UsuarioId { get; set; }
        [DataMember]
        public string Direccion { get; set; }

        [DataMember(IsRequired = false)]

        public int Estado { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public List<PedidoDetalle> detalles { get; set; }

    }
}