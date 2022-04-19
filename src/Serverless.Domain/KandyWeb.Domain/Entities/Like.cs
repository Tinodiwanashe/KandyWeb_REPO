using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        public DateTime LikedOn { get; set; }
        public virtual Resume Resume { get; set; }
        public string ResumeId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public string UserProfileId { get; set; }
    }
}
