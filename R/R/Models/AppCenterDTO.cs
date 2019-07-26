using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace R.Models
{
    [DataContract]
    public class AppCenterDTO
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string InnerExceptionMessage { get; set; }
        [DataMember]
        public string ExcName { get; set; }
    }
}

