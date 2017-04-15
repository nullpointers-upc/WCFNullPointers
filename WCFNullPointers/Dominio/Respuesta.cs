using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFNullPointers.Dominio
{
    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string data { get; set; }
        [DataMember]
        public string error { get; set; }
    }
}
