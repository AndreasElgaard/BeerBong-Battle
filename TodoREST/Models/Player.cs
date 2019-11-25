using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
   public class Player
    {
        public int PlayerId { get; set; }
        public string UserId { get; set; }
        public int? gameId { get; set; }
        public int? queueId { get; set; }
        public int? leaderBoardId { get; set; }
        public List<Stats> Stats { get; set; }
    }
}
