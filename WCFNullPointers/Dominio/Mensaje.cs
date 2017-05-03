using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFNullPointers.Dominio
{
    public class Mensaje
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int Estado { get; set; }
    }
}