using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Controllers.Responses
{
    [DataContract]
    public class PlayerResponse
    {
        [DataMember]
        public int PlayerId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public  int? GameId { get; set; }
        [DataMember]
        public int? QueueId { get; set; }
        [DataMember]
        public int? LeaderBoardId { get; set; }
        [DataMember]
        public IEnumerable<StatsResponse> Stats { get; set; }
    }
}
