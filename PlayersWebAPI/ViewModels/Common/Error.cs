using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PlayersWebAPI.Models.Common
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Error
    {
        [Required]
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [Required]
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "details")]
        public List<ErrorDetail> Details { get; set; }
    }
}
