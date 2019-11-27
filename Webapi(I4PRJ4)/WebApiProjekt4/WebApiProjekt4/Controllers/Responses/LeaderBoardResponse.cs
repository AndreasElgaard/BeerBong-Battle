using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Controllers.Responses
{
    [DataContract]
    public class LeaderBoardResponse
    {
        [DataMember]
        public int LeaderBoardId { get; set; }
        [DataMember]
        public IEnumerable<PlayerResponse> Players { get; set; }
    }
}
