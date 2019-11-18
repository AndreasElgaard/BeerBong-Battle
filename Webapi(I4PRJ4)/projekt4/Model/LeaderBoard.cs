using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class LeaderBoard 
    {
        [Key]
        [Column("id")]
        public int LeaderBoardId { get; set; }
        [Column("Best Time")]
        public string Time { get; set; }

        public ICollection<Bruger> Brugers { get; set; }
    }
}
