using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class AuthenticationResultlogin
    {
        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public IEnumerable<string> ErrorMessage { get; set; }

        [DataMember]
        public int PlayerId { get; set; }
    }
}
