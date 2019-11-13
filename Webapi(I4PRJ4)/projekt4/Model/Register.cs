using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class Register 
    {
        [Key]
        [Column("id")]
        public int RegisterId { get; set; }
        
        public int Brugerid { get; set; }

        //public ICollection<Bruger> brugers { get; set; }

    }
}
