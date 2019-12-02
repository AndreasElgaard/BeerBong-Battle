using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
    public class WebsocketData
    {
        public string name { get; set; }
        public string state { get; set; }
        public string time { get; set; }
        public string comment { get; set; }
    }
}
