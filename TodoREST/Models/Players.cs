using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TodoREST.Models
{
    public class Players
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Time { get;}

        public override string ToString()
        {
            return this.Name;
        }
    }
}
