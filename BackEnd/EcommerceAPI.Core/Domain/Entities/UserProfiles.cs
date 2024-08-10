using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProfiles : EntityBase, IEntityBase
    {
        public string email { get; set; }
        public string phone { get; set; }
        public string image { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
        public UserProfiles() { }
        public UserProfiles(string email, string phone, string image, Guid userId) { 
            this.email = email;
            this.phone = phone;
            this.image = image;
            this.UserId = userId;
        }
    }
}
