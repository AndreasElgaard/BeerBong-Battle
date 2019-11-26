using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data
{
    public class Stats
    {
        [Key]
        [Column("id")]
        public int StatsId { get; set; }
        [Column("Drinking Time")]
        public double Time { get; set; }
        [Column("Date for Time")]
        public DateTime DateTime { get; set; }

        public int? PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}
