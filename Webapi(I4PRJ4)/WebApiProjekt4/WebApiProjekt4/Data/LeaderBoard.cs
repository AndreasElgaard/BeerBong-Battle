using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProjekt4.Data
{
    public class LeaderBoard 
    {
        [Key]
        [Column("id")]
        public int LeaderBoardId { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
