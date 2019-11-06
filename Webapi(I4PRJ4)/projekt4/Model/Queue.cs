using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class Queue : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("date_created", TypeName = "Timestamp")]
        public DateTime TimeStamp { get; set; }

        //navigation propertie
        public ICollection<Participant> Participants { get; set; }
    }
}
