using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KandyWeb.Domain.Entities
{
    public class Like: BaseEntity
    {
        [JsonProperty(PropertyName = "likedOn")]
        public DateTime LikedOn { get; set; }

        [JsonProperty(PropertyName = "resumeId")]
        public string ResumeId { get; set; }
        public virtual Resume Resume { get; set; }

        [JsonProperty(PropertyName = "userProfileId")]
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; set; }
    }
}
