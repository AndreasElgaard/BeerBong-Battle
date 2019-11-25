using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
   public class Stats
    {
        public int StatsId { get; set; }
        public double Time { get; set; }
        public DateTime DateTime { get; set; }
        public int PlayerId { get; set; }
    }
}
