using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class GameWinnerResult
    {
        [DataMember]
        public int? Playerid { get; set; }

        [DataMember]
        public double Time { get; set; }

        [DataMember]
        public DateTime DateTime { get; set; }
    }
}
