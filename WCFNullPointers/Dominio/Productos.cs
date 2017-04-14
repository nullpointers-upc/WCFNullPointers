using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class Productos
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Precio { get; set; }
        [DataMember]
        public string Descuento { get; set; }
        [DataMember]
        public string Presentacion { get; set; }
        [DataMember]
        public string CategoriaId { get; set; }
        [DataMember]
        public string Estado { get; set; }
       
    }
}