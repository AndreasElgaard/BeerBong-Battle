using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class PlayerStatsResult
    {
        [DataMember]
        public DateTime DrinkingTime { get; set; }

        [DataMember]
        public  Double Time { get; set; }
    }
}
