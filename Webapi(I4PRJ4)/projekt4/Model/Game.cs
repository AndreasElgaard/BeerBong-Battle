using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class Game : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        public ICollection<Participant> Participants { get; set; }
    }
}
