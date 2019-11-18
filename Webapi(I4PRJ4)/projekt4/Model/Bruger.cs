using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public partial class Bruger
    {
        [Key]
        [Column("id")]
        
        public int BrugerId { get; set; }
        [Column("User_Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Column("Password")]
        [StringLength(50)]
        [Required(ErrorMessage = "Password is required")]
        public string PassWord { get; set; }
        [Column("Date", TypeName = "date")]
        public DateTime DateCreated { get; set; }
        [Column("Token")]
        public string? Token { get; set; }


        public int? GameId { get; set; }
        [ForeignKey("Game id")]
        public Game Game { get; set; }

        [ForeignKey("Queue id")]
        public int? QueueId { get; set; }
        public Queue Queue { get; set; }

        [ForeignKey("Leaderboard id")]
        public int? LeaderBoardId { get; set; }
        public LeaderBoard LeaderBoard { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
