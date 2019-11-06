using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public partial class Bruger : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("User_Name")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string PassWord { get; set; }
        [Column("Password", TypeName = "date")]
        public DateTime? DateCreated { get; set; }
        [Column("Best Time")]
        public double BestTime { get; set; }

        //public Register register { get; set; }
    }
}
