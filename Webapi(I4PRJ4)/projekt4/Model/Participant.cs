using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class Participant 
    {
        [Key]
        [Column("id")]
        public int ParticipantId { get; set; }
        [Column("Participant_name")]
        [StringLength(50)]
        public string ParticipantName { get; set; }
        [Column("Result_from_drinking")]
        public double RestultTime { get; set; }

        [ForeignKey("Bruger id")]
        public int BrugerId { get; set; }
        public Bruger Bruger { get; set; }
    }
}
