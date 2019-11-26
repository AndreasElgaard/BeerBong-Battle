using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApiProjekt4.Data.Dto
{
    [DataContract]
    public class UserRegistrationRequest
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string PassWord { get; set; }
    }
}
