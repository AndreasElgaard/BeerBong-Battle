using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class TopTimes
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public double Time { get; set; }

        [DataMember]
        public DateTime DateTime { get; set; }
    }
}
