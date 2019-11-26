using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Controllers.Responses
{
    [DataContract]
    public class StatsResponse
    {
        [DataMember]
        public int StatsId { get; set; }
        [DataMember]
        public double Time { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int? PlayerId { get; set; }
    }
}
