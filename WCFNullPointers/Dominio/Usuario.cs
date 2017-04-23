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
        public string Codigo { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember(IsRequired = false)]
        public string Email { get; set; }
        [DataMember]
        public int FlagCliente { get; set; }
    }
}