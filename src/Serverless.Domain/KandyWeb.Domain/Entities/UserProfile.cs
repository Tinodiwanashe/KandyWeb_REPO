using KandyWeb.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Domain.Entities
{
    public class UserProfile: AuditableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Resume> Resumes { get; private set; }

        public virtual ICollection<Like> Likes { get; private set; }
    }
}
