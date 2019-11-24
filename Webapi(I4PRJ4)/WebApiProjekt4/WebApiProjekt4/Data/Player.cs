using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProjekt4.Data
{
    public partial class Player
    {
        [Key]
        [Column("id")]
        public int PlayerId { get; set; }


        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser identityUser { get; set; }


        public int? GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

       
        public int? QueueId { get; set; }
        [ForeignKey(nameof(QueueId))]
        public Queue Queue { get; set; }

        
        public int? LeaderBoardId { get; set; }
        [ForeignKey(nameof(LeaderBoardId))]
        public LeaderBoard LeaderBoard { get; set; }


        public ICollection<Stats> Stats { get; set; }

    }
}
