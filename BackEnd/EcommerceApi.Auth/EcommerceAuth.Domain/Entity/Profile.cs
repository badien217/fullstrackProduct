using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Domain.Entity
{
    public class Profile : EntityBase, IEntityBase
    {
        
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public string avatar { get; set; }
        public User user { get; set; }
    }
}
