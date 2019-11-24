using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
   public class LoginResponse
    {
        public string token { get; set; }
        public bool success { get; set; }
        public object errorMessage { get; set; }
    }
}
