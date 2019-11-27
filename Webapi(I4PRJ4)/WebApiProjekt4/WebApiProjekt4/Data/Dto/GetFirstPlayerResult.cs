using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class GetFirstPlayerResult
    {
        [DataMember]
        public int PlayerId { get; set; }

        [DataMember]
        public string BrugerNavn { get; set; }
    }
}
