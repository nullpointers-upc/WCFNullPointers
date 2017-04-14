using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public int Descuento { get; set; }
        [DataMember]
        public string Presentacion { get; set; }
        [DataMember]
        public int CategoriaId { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}