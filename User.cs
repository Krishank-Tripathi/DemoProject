using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceuser_login
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}