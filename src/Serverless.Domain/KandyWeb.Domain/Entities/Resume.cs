using KandyWeb.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Domain.Entities
{
    public class Resume: AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Views { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public string UserProfileId { get; set; }

        public virtual ICollection<Like> Likes { get; private set; }
    }
}
