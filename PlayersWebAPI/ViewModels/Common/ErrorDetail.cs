using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PlayersWebAPI.Models.Common
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ErrorDetail
    { 
        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [Required]
        [DataMember(Name="location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [Required]
        [DataMember(Name="message")]
        public string Message { get; set; }
    }
}
