using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Controllers.Requests
{
    [DataContract]
    public class StatsRequest
    {
        [DataMember]
        public double Time { get; set; }
        [DataMember]
        public int? PlayerId { get; set; }
    }
}
