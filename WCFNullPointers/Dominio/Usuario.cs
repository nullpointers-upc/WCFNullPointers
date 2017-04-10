using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }
    }
}